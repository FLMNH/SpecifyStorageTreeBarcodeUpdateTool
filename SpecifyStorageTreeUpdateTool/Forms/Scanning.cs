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
        private int scanCount;
        private int slocCount = -1;

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
            toolStripStatusLabelCollection.Text = sp.CollectionName;
            if (sp.GetLogTableExists())
            {
                scanLogToolStripMenuItem.Visible = true;
            } 
            tbOutput.AppendText("Start " + sp.AgentName + " using " + sp.Database + " on " + sp.Server + " at " + DateTime.Now.ToString() + ".");
            tbOutput.AppendText(Environment.NewLine);
            tbInput.Focus();
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
            lblError.Text = String.Empty;
            bool safeScan = Properties.Settings.Default.VerifyCollectionCodeInBarcode;
            if ( (input.Length > 5 && input.Substring(0,5).Equals("SHELF")) || (input.Length > 4 && input.Substring(0,4).Equals("SLOC")) )
            {
                try
                {
                    if (input.Substring(0, 4).Equals("SLOC"))
                    {
                        if (safeScan)
                        {
                            if (input.Substring(4,sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
                            {
                                storageID = int.Parse(input.Substring(4 + sp.CollectionName.Length));
                            }
                        }
                        else
                        {
                            storageID = int.Parse(input.Substring(4));
                        }
                    }
                    else if (input.Substring(0, 5).Equals("SHELF"))
                    {
                        if (safeScan)
                        {
                            if (input.Substring(5,sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
                            {
                                storageID = int.Parse(input.Substring(5 + sp.CollectionName.Length));
                            }
                        }
                        else
                        {
                            storageID = int.Parse(input.Substring(5));
                        }
                    }
                    if (sp.IsValidStorageID(storageID))
                    {
                        string sLocName = sp.GetStorageIDName(storageID);
                        slocCount = sp.GetSLOCCount(storageID);
                        lblStatus.Text = "Storage Location set to " + sLocName + ".";
                        tbOutput.AppendText("Storage Location set to " + sLocName + ".");
                        tbOutput.AppendText(Environment.NewLine);
                        lblSLOCCount.Text = slocCount.ToString();
                    }
                    else
                    {
                        storageID = -1;
                        lblError.Text = "Bad Storage Location " + input + ". Scan shelf label to begin.";
                    }
                }
                catch
                {
                    lblError.Text = "Bad Storage Location " + input + ". Scan a storage location label to begin.";
                }
                
            }
            else if (input.Length > 5 && input.Substring(0,4).Equals("CLOC"))
            {
                string containerID = "";
                if (safeScan)
                {
                    if (input.Substring(4,sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
                    {
                        containerID = input.Substring(4 + sp.CollectionName.Length);
                    }
                }
                else
                {
                    containerID = input.Substring(4);
                }
                if (storageID != -1 && sp.IsValidContainerID(containerID))
                {
                    tbOutput.AppendText("Begin processing Container Location: " + containerID + ".");
                    tbOutput.AppendText(Environment.NewLine);
                    List<int> prepIDs = sp.GetContainerLocationPrepIDs(containerID);
                    foreach (int prepID in prepIDs)
                    {
                        if (sp.UpdatePreparationStorageID(prepID,storageID))
                        {
                            string storageLocationName = sp.GetStorageIDName(storageID);
                            tbOutput.AppendText(sp.GetPrepName(prepID) + " shelved to " + storageLocationName);
                            tbOutput.AppendText(Environment.NewLine);
                            if (sp.LoggingEnabled)
                                sp.Log(prepID, storageLocationName, storageID);
                            scanCount++;
                            lblScanCount.Text = "Scan Count: " + scanCount.ToString();
                            slocCount = sp.GetSLOCCount(storageID);
                            lblSLOCCount.Text = slocCount.ToString();
                        }
                        else
                        {
                            lblError.Text = prepID.ToString() + " not valid prep ID.";
                        }
                    }
                    tbOutput.AppendText("End processing Container Location: " + containerID + ".");
                    tbOutput.AppendText(Environment.NewLine);
                }
                else
                {
                    tbOutput.AppendText("ContainerID " + containerID + " not found.");
                    tbOutput.AppendText(Environment.NewLine);
                }
            }
            else if (storageID != -1)
            {
                try
                {
                    int prepID = 0;
                    if (safeScan)
                    {
                        if (input.Substring(0, sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
                        {
                            prepID = Convert.ToInt32(input.Substring(sp.CollectionName.Length));
                        }
                    }
                    else
                    {
                        prepID = Convert.ToInt32(input);
                    }
                    if (sp.IsValidPrepID(prepID) && sp.UpdatePreparationStorageID(prepID, storageID))
                    {
                        string storageLocationName = sp.GetStorageIDName(storageID);
                        tbOutput.AppendText(sp.GetPrepName(prepID) + " shelved to " + storageLocationName);
                        tbOutput.AppendText(Environment.NewLine);
                        if (sp.LoggingEnabled)
                            sp.Log(prepID, storageLocationName, storageID);
                        scanCount++;
                        lblScanCount.Text = "Scan Count: " + scanCount.ToString();
                        slocCount = sp.GetSLOCCount(storageID);
                        lblSLOCCount.Text = slocCount.ToString();
                    }
                    else
                    {
                        lblError.Text = input + " not valid prep ID.";
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = input + " not a value prep ID";
                }
                
            }
            else
            {
                lblError.Text = input + " unrecognized.";
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            sp.CloseConnection();
            base.OnFormClosing(e);
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ConfigForm cf = new Forms.ConfigForm(sp);
            cf.ShowDialog();
        }

        private void updatePrepBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp.UpdatePrepBarcodes())
            {
                MessageBox.Show("Empty preparation barcodes filled.Yum!");
            }
            else
            {
                MessageBox.Show("Failed to update empty preparation barcodes. Might want to check on that.");
            }
        }

        private void updateStorageBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp.UpdateStorageBarcodes())
            {
                MessageBox.Show("Empty storage node barcodes filled. Yum!");
            }
            else
            {
                MessageBox.Show("Failed to update empty storage barcodes. Might want to check on that. Is the field set correctly in config?");
            }
        }

        private void scanLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ScanLog form = new Forms.ScanLog(sp);
            form.ShowDialog();
        }
    }
}
