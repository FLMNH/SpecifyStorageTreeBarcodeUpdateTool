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
        MySql.Data.MySqlClient.MySqlConnection conn;
        private bool isConnected;
        private int agentID;
        private string userName;
        private string database;
        private string server;

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

        public bool IsConnected()
        {
            return isConnected;
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
                    string sql = "UPDATE preparation SET StorageID = @storageId WHERE GUID = @prepGUID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@storageId", storageId);
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
    }
}
