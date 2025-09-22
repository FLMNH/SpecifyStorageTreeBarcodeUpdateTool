using Newtonsoft.Json;
using SpecifyStorageTreeUpdateTool.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecifyStorageTreeUpdateTool
{
    public partial class LoginScreen : Form
    {
        private readonly string userPropertiesFilePath = Application.UserAppDataPath + "\\ScanToolUserProperties.json";
        private List<UserProperty> userProperties;

        public LoginScreen()
        {
            InitializeComponent();
            tbServerName.Text = Properties.Settings.Default.MySQLServer;
            tbDBName.Text = Properties.Settings.Default.MySQLDatabase;
            tbCollectionName.Text = Properties.Settings.Default.SpecifyCollectionName;
            tbUserName.Text = Properties.Settings.Default.SpecifyUser;
            tbKey.Text = Properties.Settings.Default.SpecifyUserKey;
            this.userProperties = getUserProperties();
        }

        private List<UserProperty> getUserProperties()
        { 
            if (File.Exists(Application.UserAppDataPath + "\\ScanToolUserProperties.json"))
            {
                return JsonConvert.DeserializeObject<List<UserProperty>>(File.ReadAllText(userPropertiesFilePath));
            }
            return new List<UserProperty>(); 
        }

        private UserProperty GetUserProperty(string username, string dbServerAddress, string dbName, string collectionName)
        {
            foreach (var user in userProperties)
            {
                if (user.username.Equals(username) 
                    && user.dbServerAddress.Equals(dbServerAddress) 
                    && user.dbName.Equals(dbName)
                    && user.collectionName.Equals(collectionName))
                    { return user; }
            }
            return null;
        }

        private void SaveUserProperty(UserProperty userProperty)
        {
            foreach (var user in userProperties)
            {
                if (user.username.Equals(userProperty.username) 
                    && user.dbServerAddress.Equals(userProperty.dbServerAddress)
                    && user.dbName.Equals(userProperty.dbName)
                    && user.collectionName.Equals(userProperty.collectionName))
                { 
                    userProperties.Remove(user);
                    break;
                }
            }
            userProperties.Add(userProperty);
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(userPropertiesFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, userProperties);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Length > 0
                && tbServerName.Text.Length > 0
                && tbDBName.Text.Length > 0
                && tbPassword.Text.Length > 0
                && tbKey.Text.Length > 0)
            {
                try
                {
                    SpecifyTools sp = new SpecifyTools(tbServerName.Text, tbDBName.Text, tbCollectionName.Text, tbUserName.Text, tbPassword.Text, tbKey.Text);
                    if (sp.IsConnected)
                    {
                        Properties.Settings.Default.MySQLServer = tbServerName.Text;
                        Properties.Settings.Default.MySQLDatabase = tbDBName.Text;
                        Properties.Settings.Default.SpecifyCollectionName = tbCollectionName.Text;
                        Properties.Settings.Default.SpecifyUser = tbUserName.Text;
                        Properties.Settings.Default.SpecifyUserKey = tbKey.Text;
                        Properties.Settings.Default.Save();
                        lblStatus.Text = "Connected.";
                        if (sp.IsAuthorized)
                        {
                            UserProperty currentUser = new UserProperty(tbUserName.Text, tbKey.Text, tbServerName.Text, tbDBName.Text, tbCollectionName.Text);
                            SaveUserProperty(currentUser);
                            lblStatus.Text += " " + tbUserName.Text + " authorized for prep modify.";
                            this.Hide();
                            Scanning scanning = new Scanning(sp);
                            scanning.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            lblStatus.Text += tbUserName.Text + " not authorized for prep modify.";
                            sp.CloseConnection();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Connection failed.");
                    }
                }
                catch (CryptographicException ex)
                {
                    lblStatus.Text = "Bad username, password, and key combination.";
                }
            }
            else
            {
                MessageBox.Show("Complete all fields.");
            }
        }

        private void tbUserName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbUserName.Text)
                && !string.IsNullOrWhiteSpace(tbServerName.Text)
                && !string.IsNullOrWhiteSpace(tbDBName.Text)
                && !string.IsNullOrWhiteSpace(tbCollectionName.Text))
            {
                UserProperty user = GetUserProperty(tbUserName.Text,tbServerName.Text,tbDBName.Text,tbCollectionName.Text);
                if (user != null)
                {
                    tbKey.Text = user.key;
                }
            }
        }

        private void login_LoadEvent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbServerName.Text))
            {
                tbPassword.Select();
            }
        }
    }
}
