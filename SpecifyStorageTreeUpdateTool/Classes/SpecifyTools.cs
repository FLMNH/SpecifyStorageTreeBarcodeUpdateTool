using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private string userName;
        private string collectionName;
        private string database;
        private string server;

        public bool IsConnected { get { return isConnected; } }
        public bool IsAuthorized { get { return isAuthorized; } }
        public string AgentName {  get { return userName; } }
        public string Database { get { return database; } }
        public string Server { get { return server; } }
        public string CollectionName { get { return collectionName; } }

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
                    this.userName = userName;
                    this.database = dbName;
                    this.server = dbServer;
                    isConnected = true;
                    if (hasPreparationModify(userName, userPassword, collectionName))
                    {
                        this.collectionName = collectionName;
                        isAuthorized = true;
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
                    bool auth = isLimitedUserWithPrepModify(getSpPrincipalID(getSpecifyUserID(username, password), collectionName));
                    if (!auth)
                    {
                        return auth;
                    }
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
                if (result != DBNull.Value)
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

        public bool IsValidPrepID(int prepID)
        {
            if (isConnected)
            {
                try
                {
                    string sql = "SELECT count(PreparationID) FROM preparation WHERE PreparationID = @prepID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@prepID", prepID);
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
                    string sql = "SELECT count(GUID) FROM preparation WHERE GUID = @GUID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@GUID", GUID);
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
