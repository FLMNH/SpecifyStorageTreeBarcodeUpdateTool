using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecifyStorageTreeUpdateTool.Forms
{
    public partial class ConfigForm : Form
    {
        private SpecifyTools sp;
        private bool initDone = false;

        public ConfigForm()
        {
            InitializeComponent();
        }

        public ConfigForm(SpecifyTools sp)
        {
            InitializeComponent();
            this.sp = sp;
            enableAuditLogCheckbox.Checked = sp.LoggingEnabled;
            tbStorageBarcodeField.Text = sp.StorageBarcodeFieldName;
            tbPrepContainerField.Text = sp.PrepContainerIDField;
            verifyCollectionCodeInBarcodecheckBox.Checked = Properties.Settings.Default.VerifyCollectionCodeInBarcode;
            initDone = true;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sp.StorageBarcodeFieldName = tbStorageBarcodeField.Text;
            sp.PrepContainerIDField = tbPrepContainerField.Text;
            Properties.Settings.Default.StorageBarcodeField = sp.StorageBarcodeFieldName;
            Properties.Settings.Default.PrepContainerIDField = sp.PrepContainerIDField;
            Properties.Settings.Default.VerifyCollectionCodeInBarcode = verifyCollectionCodeInBarcodecheckBox.Checked;
            Properties.Settings.Default.Save(); 
            this.Close();
        }

        private void enableAuditLogCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableAuditLogCheckbox.Checked && initDone)
            {
                if (sp.LogTableExists)
                {
                    MessageBox.Show("Log table already exists. Will enable auditing");
                    sp.LoggingEnabled = true;
                }
                else
                {
                    if (MessageBox.Show("Log table not found.\nEnabling audit logging requires the IT Master username and password to create the table in the Specify database to store the audit log.", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        MasterUserNameLabel.Visible = true;
                        MasterUserNameTextBox.Visible = true;
                        MasterPasswordLabel.Visible = true;
                        MasterPasswordTextBox.Visible = true;
                        CreateTableEnableLogginButton.Visible = true;

                    }
                }
            }

            if (!enableAuditLogCheckbox.Checked && initDone)
            {
                sp.LoggingEnabled = false;
                string disableMessage = "Logging for this sessiond disabled.\nDrop or rename the fmstoragescanninglog table in your Specify database to persistently disable logging.";
                disableMessage += "\nRename the table if you wish to retain previous log data. Or, export a copy of the table before dropping.";
                disableMessage += "\nThe application will automatically enable logging on launch when the table is present.";
                MessageBox.Show(disableMessage);
            }
        }

        private void CreateTableEnableLogginButton_Click(object sender, EventArgs e)
        {
            if (sp.IsCorrectMaster(MasterUserNameTextBox.Text.Trim(), MasterPasswordTextBox.Text.Trim()))
            {
                if (sp.CreateLogTable())
                {
                    MessageBox.Show("Table created and logging enabled.");
                    sp.LoggingEnabled = true;
                    MasterUserNameLabel.Visible = false;
                    MasterUserNameTextBox.Visible = false;
                    MasterUserNameTextBox.Text = String.Empty;
                    MasterPasswordLabel.Visible = false;
                    MasterPasswordTextBox.Visible = false;
                    MasterPasswordTextBox.Text = String.Empty;
                    CreateTableEnableLogginButton.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("IT Master username or password not correct.");
                enableAuditLogCheckbox.Checked = false;
                MasterUserNameLabel.Visible = false;
                MasterUserNameTextBox.Visible = false;
                MasterUserNameTextBox.Text = String.Empty;
                MasterPasswordLabel.Visible = false;
                MasterPasswordTextBox.Visible = false;
                MasterPasswordTextBox.Text = String.Empty;
                CreateTableEnableLogginButton.Visible = false;

            }
        }
    }
}
