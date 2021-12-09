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
        private int agentID;
        private string userName;
        private string database;
        private string server;

        public bool IsConnected { get { return isConnected; } }
        public string AgentName {  get { return userName; } }
        public string Database { get { return database; } }
        public string Server { get { return server; } }

        public SpecifyTools()
        {

        }

        public SpecifyTools(string dbServer, string dbName, string userName, string userPassword, string userKey)
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
                }
            }
            catch (MySqlException ex)
            {
                isConnected = false;
                MessageBox.Show(ex.Message);
            }

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
