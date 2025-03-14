using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SpecifyStorageTreeUpdateTool
{
    public class SpecifyTools
    {
        private static MySql.Data.MySqlClient.MySqlConnection conn;
        private static bool isConnected;
        private static bool isAuthorized;
        private int agentID;
        private int collectionID;
        private string userName;
        private string collectionName;
        private string database;
        private string server;
        private bool logTableExists;
        private string masterUsername;
        private string masterPassword;
        private bool loggingEnabled;
        private string storageBarcodeField;
        private string prepContainerIDField;

        public bool IsConnected { get { return isConnected; } }
        public bool IsAuthorized { get { return isAuthorized; } }
        public string AgentName {  get { return userName; } }
        public string Database { get { return database; } }
        public string Server { get { return server; } }
        public string CollectionName { get { return collectionName; } }
        public bool LogTableExists { get { return logTableExists; } }
        public bool LoggingEnabled {
            get { return loggingEnabled; }
            set { loggingEnabled = value; }
        }
        public string StorageBarcodeFieldName { 
            get { return storageBarcodeField; } 
            set { storageBarcodeField = value; }    
        }
        public string PrepContainerIDField
        {
            get { return prepContainerIDField; }
            set { prepContainerIDField = value; }
        }

        public SpecifyTools()
        {

        }

        public SpecifyTools(string dbServer, string dbName, string collectionName, string userName, string userPassword, string userKey)
        {
            Decryptor decryptor = new Decryptor();
            string[] master = decryptor.decrypt(userKey, userPassword).Split(',');
            string connectionString = "server=" + dbServer + ";uid=" + master[0] + ";pwd=" + master[1] + ";database=" + dbName;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                int agentID = getAgentID(getSpecifyUserID(userName, userPassword));
                if (agentID != -1)
                {
                    this.agentID = agentID;
                    this.collectionID = getCollectionID(collectionName);
                    this.userName = userName;
                    this.database = dbName;
                    this.server = dbServer;
                    isConnected = true;
                    this.logTableExists = GetLogTableExists();
                    this.masterUsername =master[0];
                    this.masterPassword =master[1];
                    this.loggingEnabled = GetLogTableExists();
                    if (hasPreparationModify(userName, userPassword, collectionName))
                    {
                        this.collectionName = collectionName;
                        isAuthorized = true;
                    }
                    if (Properties.Settings.Default.StorageBarcodeField == String.Empty)
                    {
                        Properties.Settings.Default.StorageBarcodeField = "number1";
                        storageBarcodeField = "number1";
                    }
                    else
                    {
                        storageBarcodeField = Properties.Settings.Default.StorageBarcodeField;
                    }
                    if (Properties.Settings.Default.PrepContainerIDField == String.Empty)
                    {
                        Properties.Settings.Default.PrepContainerIDField = "text2";
                        prepContainerIDField = "text2";
                    }
                    else
                    {
                        prepContainerIDField = Properties.Settings.Default.PrepContainerIDField;
                    }
                }
            }
            catch (MySqlException ex)
            {
                isConnected = false;
                MessageBox.Show(ex.Message);
            }

        }

        private bool hasPreparationModify(string username, string password, string collectionName)
        {
            if (isCollectionName(collectionName))
            {
                string userType = getSpecifyUserType(username, password, collectionName);
                if (userType.Equals("Manager"))
                {
                    return true;
                }
                else if (userType.Equals("LimitedAccess"))
                {
                    return isLimitedUserWithPrepModify(getSpPrincipalID(getSpecifyUserID(username, password), collectionName)) ||
                        isLimitedUserWithPrepModify(getLimitedAccessSpPrincipalID(username, password, collectionName));
                }
            }
            return false;
        }

        private bool isLimitedUserWithPrepModify(int spPrincipalID)
        {
            try
            {
                string sql = @"SELECT 
	                                p.Actions
                                from 
	                                sppermission p
                                    inner join spprincipal_sppermission pp on p.SpPermissionID = pp.SpPermissionID
                                where 
	                                p.Name = 'DO.preparation'  
                                    and pp.SpPrincipalID = @spPrincipalID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@spPrincipalID", spPrincipalID);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return result.ToString().Contains("modify");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private int getSpPrincipalID(int userID, string collectionName)
        {
            try
            {
                string sql = @"select 
	                                spprincipal.SpPrincipalID
                                from 
	                                spprincipal 
                                    inner join specifyuser_spprincipal on spprincipal.SpPrincipalID = specifyuser_spprincipal.SpPrincipalID
                                    inner join specifyuser on specifyuser_spprincipal.SpecifyUserID = specifyuser.SpecifyUserID
                                where 
	                                spprincipal.userGroupScopeID = @collectionID
                                    and GroupSubClass = 'edu.ku.brc.af.auth.specify.principal.UserPrincipal'
                                    and specifyuser.SpecifyUserID = @userID";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@collectionID", getCollectionID(collectionName));
                cmd.Parameters.AddWithValue("@userID", userID);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result.ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        private int getSpecifyUserID(string username, string password)
        {
            try
            {
                string sql = "SELECT SpecifyUserID, Password FROM specifyuser WHERE Name = @Name";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", username);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Decryptor decryptor = new Decryptor();
                        if (password.Equals(decryptor.decrypt(reader.GetString(1), password)))
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        private bool isCollectionName(string collectionName)
        {
            try
            {
                string sql = "select count(UserGroupScopeID) from collection where CollectionName = @collectionName";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@collectionName", collectionName);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    if (Convert.ToInt32(result.ToString()) == 1)
                    {
                        return true;
                    }    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private int getCollectionID(string collectionName)
        {
            try
            {
                string sql = "select UserGroupScopeID from collection where CollectionName = @collectionName";
                MySqlCommand cmd = new MySqlCommand( sql, conn);
                cmd.Parameters.AddWithValue("@collectionName", collectionName);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result.ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        private int getLimitedAccessSpPrincipalID(string username, string password, string collectionName)
        {
            try
            {
                string sql = @"select 
                                    spprincipal.SpPrincipalID
                                from
                                    spprincipal
                                    inner join specifyuser_spprincipal on spprincipal.SpPrincipalID = specifyuser_spprincipal.SpPrincipalID
                                    inner join specifyuser on specifyuser_spprincipal.SpecifyUserID = specifyuser.SpecifyUserID
                                where
                                    spprincipal.userGroupScopeID = @collectionID
                                    and GroupSubClass = 'edu.ku.brc.af.auth.specify.principal.GroupPrincipal'
                                    and specifyuser.SpecifyUserID = @specifyUserID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@collectionID", getCollectionID(collectionName));
                cmd.Parameters.AddWithValue("@specifyUserID", getSpecifyUserID(username, password));
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Int32.Parse( result.ToString() );
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        private string getSpecifyUserType(string username, string password, string collectionName)
        {
            try
            {
                string sql = @"select 
                                    spprincipal.groupType
                                from
                                    spprincipal
                                    inner join specifyuser_spprincipal on spprincipal.SpPrincipalID = specifyuser_spprincipal.SpPrincipalID
                                    inner join specifyuser on specifyuser_spprincipal.SpecifyUserID = specifyuser.SpecifyUserID
                                where
                                    spprincipal.userGroupScopeID = @collectionID
                                    and GroupSubClass = 'edu.ku.brc.af.auth.specify.principal.GroupPrincipal'
                                    and specifyuser.SpecifyUserID = @specifyUserID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@collectionID", getCollectionID(collectionName));
                cmd.Parameters.AddWithValue("@specifyUserID", getSpecifyUserID(username, password));
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return String.Empty;
        }

        public string GetPrepName(string prepGUID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT c.CatalogNumber, pt.Name, p.CountAmt FROM preparation p INNER JOIN collectionobject c ON p.CollectionObjectID = c.CollectionObjectID INNER JOIN preptype pt on p.PrepTypeID = pt.PrepTypeID WHERE p.GUID = @prepGUID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@prepGUID", prepGUID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetString(0).TrimStart('0') + " " + reader.GetString(1) + " " +reader.GetString(2);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return String.Empty;
        }

        public string GetPrepName(int prepID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT c.CatalogNumber, pt.Name, p.CountAmt FROM preparation p INNER JOIN collectionobject c ON p.CollectionObjectID = c.CollectionObjectID INNER JOIN preptype pt on p.PrepTypeID = pt.PrepTypeID WHERE p.PreparationID = @prepID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@prepID", prepID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetString(0).TrimStart('0') + " " + reader.GetString(1) + " " + reader.GetString(2);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return String.Empty;
        }

        private int getAgentID(int specifyUserID)
        {
            try
            {
                string sql = "SELECT AgentID FROM agent WHERE SpecifyUserID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", specifyUserID);
                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        public string GetStorageIDName(int storageId)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT FullName FROM storage WHERE StorageID = @storageID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@storageID", storageId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return String.Empty;
        }

        public int GetSLOCCount(int storageId)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "select count(PreparationID) from preparation where StorageID = @storageID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@storageID", storageId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Int32.Parse(result.ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return -1;
        }

        public string GetPrepFullDetails(int prepID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = @"SELECT 
	                                PreparationID,
                                    TRIM(LEADING 0 FROM co.CatalogNumber) AS CatalogNumber,
                                    (SELECT t.FullName 
                                    FROM determination d INNER JOIN taxon t ON d.TaxonID = t.TaxonID 
                                    WHERE d.IsCurrent = 1 and d.CollectionObjectID = p.CollectionObjectID) as TaxonName,
                                    IFNULL(s.FullName,'No StorageID') as StorageFullName
                                FROM 
	                                preparation p 
                                    INNER JOIN collectionobject co ON p.CollectionObjectID = co.CollectionObjectID 
                                    LEFT JOIN storage s ON p.StorageID = s.StorageID
                                WHERE 
	                                p.PreparationID = @prepID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@prepID", prepID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return "Barcode: " + reader.GetString(0) + " CatNum: " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return String.Empty;
        }

        public List<Preparation> GetPreparationByStorageID(int storageID)
        {
            List<Preparation> preps = new List<Preparation>();
            if(isConnected)
            {
                try
                {
                    string sql = @"SELECT 
	                                PreparationID,
                                    TRIM(LEADING 0 FROM co.CatalogNumber) AS CatalogNumber,
                                    (SELECT t.FullName 
                                    FROM determination d INNER JOIN taxon t ON d.TaxonID = t.TaxonID 
                                    WHERE d.IsCurrent = 1 and d.CollectionObjectID = p.CollectionObjectID) as TaxonName
                                FROM 
	                                preparation p 
                                    INNER JOIN collectionobject co ON p.CollectionObjectID = co.CollectionObjectID 
                                WHERE 
	                                StorageID = @storageID";
                    MySqlCommand cmd = new MySqlCommand(sql,conn);
                    cmd.Parameters.AddWithValue("@storageID",storageID);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int prepID = 0;
                    string catalogNumber,TaxonName,DisplayString;
                    while (reader.Read())
                    {
                        prepID = reader.GetInt32(0);
                        catalogNumber = reader.GetString(1);
                        TaxonName = reader.GetString(2);
                        DisplayString = String.Format("Barcode: {0}, CatNum: {1}, {2}",prepID.ToString(),catalogNumber,TaxonName);
                        preps.Add(new Preparation(prepID,DisplayString));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return preps;
        }

        public List<int> GetContainerLocationPrepIDs(string containerID)
        {
            List<int> prepIDs = new List<int>();
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT PreparationID FROM preparation WHERE " + prepContainerIDField.Replace(" ","") + " = @containerID";
                    MySqlCommand cmd = new MySqlCommand(sql,conn);
                    cmd.Parameters.AddWithValue("@containerID",containerID);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        prepIDs.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return prepIDs;
        }

        public string GetStorageNodeFullName(int storageID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT FullName FROM storage WHERE StorageID = @storageID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@storageID", storageID);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return String.Empty;
                    }
                    else
                    {
                        return result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return String.Empty;
        }

        public int GetStorageNodeParentID(int storageID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT ParentID FROM storage WHERE StorageID = @storageID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@storageID", storageID);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return int.Parse(result.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return -1;
        }

        public bool IsValidStorageID(int id)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT count(StorageID) FROM storage WHERE StorageID = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else
                    {
                        int r = Convert.ToInt32(result);
                        if (r == 1) { return true; }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool IsValidContainerID(string containerID)
        {
            if (isConnected && containerID != null && containerID != String.Empty)
            {
                try
                {
                    string sql = "SELECT count(text2) FROM preparation WHERE " + prepContainerIDField + " = @containerID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("containerID", containerID);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else
                    {
                        int r = Convert.ToInt32(result);
                        if (r >= 1) { return true; }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool IsValidPrepID(int prepID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT count(PreparationID) FROM preparation WHERE CollectionMemberID = @collectionID AND PreparationID = @prepID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@prepID", prepID);
                    cmd.Parameters.AddWithValue("@collectionID", this.collectionID);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else
                    {
                        int r = Convert.ToInt32(result);
                        if (r == 1) { return true; }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool IsValidPrepGUID(string GUID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT count(GUID) FROM preparation WHERE CollectionMemberID = @collectionID AND GUID = @GUID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@GUID", GUID);
                    cmd.Parameters.AddWithValue("@collectionID", this.collectionID);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    else
                    {
                        int r = Convert.ToInt32(result);
                        if (r == 1) { return true; }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool UpdateStorageNodeParentID(int nodeId, int parentId)
        {
            if (isConnected)
            {
                try
                {
                    string currentParentFullName = GetStorageNodeFullName(GetStorageNodeParentID(nodeId));
                    string newParentFullName = GetStorageNodeFullName(parentId);
                    string FullName = GetStorageNodeFullName(nodeId).Replace(currentParentFullName, newParentFullName);
                    string sql = "UPDATE storage SET ParentID = @parentId, FullName = @FullName, ModifiedByAgentID = @agentId, TimestampModified = NOW() WHERE StorageID = @nodeId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parentId", parentId);
                    cmd.Parameters.AddWithValue("@FullName", FullName);
                    cmd.Parameters.AddWithValue("@agentId", agentID);
                    cmd.Parameters.AddWithValue("@nodeId", nodeId);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }
        
        public bool UpdatePreparationStorageID(int prepID, int storageId)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "UPDATE preparation SET StorageID = @storageId, ModifiedByAgentID = @agentID, TimestampModified = NOW() WHERE PreparationID = @prepID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@storageId", storageId);
                    cmd.Parameters.AddWithValue("@agentID", agentID);
                    cmd.Parameters.AddWithValue("@prepID", prepID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool UpdatePreparationStorageID(string prepGUID, int storageId)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "UPDATE preparation SET StorageID = @storageId, ModifiedByAgentID = @agentID, TimestampModified = NOW() WHERE GUID = @prepGUID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@storageId", storageId);
                    cmd.Parameters.AddWithValue("@agentID", agentID);
                    cmd.Parameters.AddWithValue("@prepGUID", prepGUID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool UpdatePrepBarcodes()
        {
            if (isConnected)
            {
                try
                {
                    string sql = "UPDATE preparation SET Barcode = PreparationID WHERE CollectionMemberID = @CollectionID AND Barcode IS NULL";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CollectionID", collectionID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool UpdateStorageBarcodes()
        {
            if (isConnected)
            {
                try
                {
                    string sql = "UPDATE storage SET " + storageBarcodeField + " = StorageID WHERE " + storageBarcodeField + " IS NULL";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public bool GetLogTableExists()
        {
            try
            {
                string sql = @"SELECT EXISTS(
                                            SELECT * FROM information_schema.tables 
                                            WHERE table_schema = @DBName 
                                            AND table_name = 'fmstoragescanninglog'
                                            ) AS TableFound;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DBName", this.Database);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result.ToString()) == 1 ? true : false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        public DataSet GetScanLog(DateTime beginDate,DateTime endDate, int? prepID, int? storageID, string userName)
        {
            DataSet ds = new DataSet();
            if (isConnected)
            {
                try
                {
                    string sql = @"SELECT 
	                                    l.PrepId AS PrepBarcode,
                                        l.ScannedToFullName,
                                        l.NewStorageId AS ScannedToLoc,
                                        u.Name,
                                        l.ScanTimestamp,
                                        TRIM(LEADING '0' FROM co.CatalogNumber) AS CatalogNumber,
                                        (SELECT t.FullName from determination d 
                                        inner join taxon t on d.TaxonID = t.TaxonID 
                                        where d.CollectionObjectID = co.CollectionObjectID and ifnull(d.IsCurrent,0) = 1) as Taxon
                                    FROM 
	                                    fmstoragescanninglog l 
                                        inner join agent a ON l.ScannedByAgentID = a.AgentID
                                        inner join specifyuser u ON a.SpecifyUserID = u.SpecifyUserID
                                        inner join preparation p on l.PrepId = p.PreparationID
                                        inner join collectionobject co on p.CollectionObjectID = co.CollectionObjectID
                                    WHERE
                                        l.ScanTimestamp >= @beginDate AND l.ScanTimestamp <= @endDate ";
                    if (prepID.HasValue)
                    {
                        sql += " AND l.PrepID = @prepID";
                    }
                    if (storageID.HasValue)
                    {
                        sql += " AND l.NewStorageID = @storageID";
                    }
                    if (userName != null)
                    {
                        sql += " AND u.Name = @userName";
                    }
                    sql += " ORDER BY l.ScanTimestamp DESC;";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@beginDate", beginDate);
                    da.SelectCommand.Parameters.AddWithValue("@endDate", endDate);
                    if (prepID.HasValue)
                    {
                        da.SelectCommand.Parameters.AddWithValue("@prepID", prepID);
                    }
                    if (storageID.HasValue)
                    {
                        da.SelectCommand.Parameters.AddWithValue("@storageID", storageID);
                    }
                    if (userName != null)
                    {
                        da.SelectCommand.Parameters.AddWithValue("@userName", userName);
                    }
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    da.Fill(ds, "Logs");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return ds;
        }

        public bool CreateLogTable()
        {
            try
            {
                if (!logTableExists)
                {
                    string sql = @"CREATE TABLE `fmstoragescanninglog` (
                                `fmstoragescanninglogId` INT NOT NULL AUTO_INCREMENT,
                                `PrepId` INT NOT NULL,
                                `ScannedToFullName` VARCHAR(255) NOT NULL,
                                `NewStorageId` INT NOT NULL,
                                `ScannedByAgentId` INT NOT NULL,
                                `ScanTimestamp` DATETIME NOT NULL,
                                PRIMARY KEY (`fmstoragescanninglogId`));";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteScalar();
                    this.logTableExists = GetLogTableExists();
                    return this.logTableExists;
                }                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        public bool IsCorrectMaster(string MasterUsername, string MasterPassword)
        {
            return MasterUsername == this.masterUsername && MasterPassword == this.masterPassword;
        }

        public bool Log(int prepId, string storageName, int storageId)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "INSERT INTO fmstoragescanninglog (PrepId,ScannedToFullName,NewStorageId,ScannedByAgentId,ScanTimestamp)";
                    sql += " VALUES (@prepId,@storageName,@storageId,@agentId,NOW())";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@prepId", prepId);
                    cmd.Parameters.AddWithValue("@storageName", storageName);
                    cmd.Parameters.AddWithValue("@storageId", storageId);
                    cmd.Parameters.AddWithValue("@agentId", this.agentID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return false;
        }

        public void CloseConnection()
        {
            if (isConnected)
            {
                conn.Close();
                isConnected = false;
            }
        }
    }
}
