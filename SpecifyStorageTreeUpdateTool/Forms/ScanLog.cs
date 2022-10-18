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
    public partial class ScanLog : Form
    {
        private SpecifyTools sp;

        public ScanLog()
        {
            InitializeComponent();
        }

        public ScanLog(SpecifyTools sp)
        {
            InitializeComponent();
            this.sp = sp;
            dateTimePickerBeginDate.Value = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            dateTimePickerEndDate.Value = DateTime.Now;
        }

        private void textBoxPrepID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxStorageID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonRunReport_Click(object sender, EventArgs e)
        {
            int? prepID = null;
            int? storageID = null;
            string agent = null;
            if(textBoxPrepID.Text.Length > 0)
            {
                prepID = int.Parse(textBoxPrepID.Text);
            }
            if(textBoxStorageID.Text.Length > 0)
            {
                storageID = int.Parse(textBoxStorageID.Text);
            }
            if(textBoxScannedBy.Text.Length > 0)
            {
                agent = textBoxScannedBy.Text;
            }
            DataSet dsLog = sp.GetScanLog(dateTimePickerBeginDate.Value,
                                          dateTimePickerEndDate.Value,
                                          prepID,
                                          storageID,
                                          agent);
            dataGridViewLogs.DataSource = dsLog;
            dataGridViewLogs.DataMember = "Logs";
        }
    }
}
