using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SpecifyStorageTreeUpdateTool
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            tbServerName.Text = Properties.Settings.Default.MySQLServer;
            tbDBName.Text = Properties.Settings.Default.MySQLDatabase;
            tbCollectionName.Text = Properties.Settings.Default.SpecifyCollectionName;
            tbUserName.Text = Properties.Settings.Default.SpecifyUser;
            tbKey.Text = Properties.Settings.Default.SpecifyUserKey;
            
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
    }
}
