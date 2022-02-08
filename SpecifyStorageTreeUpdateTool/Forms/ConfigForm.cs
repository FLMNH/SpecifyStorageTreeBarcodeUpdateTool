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
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enableAuditLogCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableAuditLogCheckbox.Checked)
            {
                // Need to first check if the table exists and branch accordingly.
               if ( MessageBox.Show("Enabling audit logging requires the IT Master username and password to create the table in the Specify database to store the audit log.","Warning",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    MessageBox.Show("Prompt for Master username and passowrd.");
                    
                }
            }
        }
    }
}
