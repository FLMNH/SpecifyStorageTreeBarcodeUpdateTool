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

        public SpecifyTools()
        {
          
        }

        public SpecifyTools(string dbServer, string dbName, string dbUser, string dbPassword)
        {
            string connectionString = "server=" + dbServer + ";uid=" + dbUser + ";pwd=" + dbPassword + ";database=" + dbName;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                isConnected = true;
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
                    string sql = "UPDATE preparation SET StorageID = @storageId where GUID = @prepGUID";
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
