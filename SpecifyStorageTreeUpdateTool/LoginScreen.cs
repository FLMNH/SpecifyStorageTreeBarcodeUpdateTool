using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                SpecifyTools sp = new SpecifyTools(tbServerName.Text, tbDBName.Text, tbCollectionName.Text, tbUserName.Text, tbPassword.Text, tbKey.Text);
                if (sp.IsConnected)
                {
                    Properties.Settings.Default.MySQLServer = tbServerName.Text;
                    Properties.Settings.Default.MySQLDatabase = tbDBName.Text;
                    Properties.Settings.Default.SpecifyCollectionName = tbCollectionName.Text;
                    Properties.Settings.Default.SpecifyUser = tbUserName.Text;
                    Properties.Settings.Default.SpecifyUserKey = tbKey.Text;
                    Properties.Settings.Default.Save();
                    this.Hide();
                    Scanning scanning = new Scanning(sp);
                    scanning.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Connection failed.");
                }
            }
            else
            {
                MessageBox.Show("Complete all fields.");
            }
        }
    }
}
