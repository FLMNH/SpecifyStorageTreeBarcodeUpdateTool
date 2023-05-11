using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            Cursor.Current = Cursors.WaitCursor;
            DataSet dsLog = sp.GetScanLog(dateTimePickerBeginDate.Value,
                                          dateTimePickerEndDate.Value,
                                          prepID,
                                          storageID,
                                          agent);
            dataGridViewLogs.DataSource = dsLog;
            dataGridViewLogs.DataMember = "Logs";
            labelRecordCount.Text = "Record Count: " + dsLog.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Scan Report";
            saveFileDialog.FileName = "ScanLog-" + dateTimePickerBeginDate.Value.ToLocalTime().ToString("yyyyMMdd") + "-" + dateTimePickerEndDate.Value.ToLocalTime().ToString("yyyyMMdd") + "-" + sp.Database + ".csv";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                var headers = dataGridViewLogs.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));
                foreach (DataGridViewRow row in dataGridViewLogs.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }
                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }
    }
}
