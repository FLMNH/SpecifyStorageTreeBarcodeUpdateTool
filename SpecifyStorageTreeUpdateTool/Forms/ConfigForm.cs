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

        public ConfigForm()
        {
            InitializeComponent();
        }

        public ConfigForm(SpecifyTools sp)
        {
            InitializeComponent();
            this.sp = sp;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enableAuditLogCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableAuditLogCheckbox.Checked)
            {
                if (sp.LogTableExists)
                {
                    MessageBox.Show("Log table already exists. Will enable auditing");
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
        }

        private void CreateTableEnableLogginButton_Click(object sender, EventArgs e)
        {

        }
    }
}
