using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecifyStorageTreeUpdateTool
{
    public partial class Scanning : Form
    {
        private int storageID = -1;
        private SpecifyTools sp;

        public Scanning()
        {
            InitializeComponent();
        }

        public Scanning(SpecifyTools sp)
        {
            InitializeComponent();
            this.sp = sp;
            toolStripStatusUserName.Text = sp.AgentName;
            toolStripStatusDatabase.Text = sp.Database;
            toolStripStatusServer.Text = sp.Server;
            tbOutput.AppendText("Start " + sp.AgentName + " using " + sp.Database + " on " + sp.Server + " at " + DateTime.Now.ToString() + ".");
            tbOutput.AppendText(Environment.NewLine);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void enterKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processInput(tbInput.Text.Trim());
                tbInput.Clear();
            }
        }

        private void processInput(string input)
        {
            if (input.Length > 5 && input.Substring(0,5).Equals("Shelf"))
            {
                try
                {
                    if (sp.IsValidStorageID(int.Parse(input.Substring(5))))
                    {
                        storageID = int.Parse(input.Substring(5));
                        lblStatus.Text = "Shelf set to " + storageID + ".";
                        tbOutput.AppendText("Shelf set to " + storageID + ".");
                        tbOutput.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        lblStatus.Text = "Bad shelf ID " + input.Substring(5) + ". Scan shelf label to begin.";
                    }
                }
                catch
                {
                    lblStatus.Text = "Bad shelf ID " + input.Substring(5) + ". Scan shelf label to begin.";
                }
                
            }
            else if (storageID != -1 && input.Length == 36 && sp.IsValidPrepGUID(input))
            {
                if (sp.UpdatePreparationStorageID(input, storageID))
                {
                    tbOutput.AppendText(input + " set to " + storageID);
                    tbOutput.AppendText(Environment.NewLine);
                }
                else
                {
                    lblStatus.Text = input + " not valid prep GUID.";
                }
            }
            else
            {
                lblStatus.Text = input + " unrecognized.";
            }
        }

        private void saveScanHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.Title = "Save Scan History";
            saveFileDialog.FileName = DateTime.Now.ToLocalTime().ToString("yyyyMMddhhmm") + "-" + sp.AgentName + "-" + sp.Database + ".txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, tbOutput.Text);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveScanHistoryToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
