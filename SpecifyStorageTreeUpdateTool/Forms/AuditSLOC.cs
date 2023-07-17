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

namespace SpecifyStorageTreeUpdateTool.Forms
{
    public partial class AuditSLOC : Form
    {
        private SpecifyTools sp;
        private int storageID = -1;
        private BindingList<Preparation> unscannedPreps = new BindingList<Preparation>();
        private BindingList<Preparation> scannedPreps = new BindingList<Preparation>();
        private BindingList<Preparation> extraPreps = new BindingList<Preparation>();

        public AuditSLOC()
        {
            InitializeComponent();
        }

        public AuditSLOC(SpecifyTools sp)
        {
            InitializeComponent();
            this.sp = sp;
            unscannedPreps.AllowNew = true;
            unscannedPreps.AllowRemove = true;
            lbUnscanned.DataSource = unscannedPreps;
            lbUnscanned.DisplayMember = "DisplayString";
            scannedPreps.AllowNew = true;
            scannedPreps.AllowRemove = true;
            lbScanned.DataSource = scannedPreps;
            lbScanned.DisplayMember = "DisplayString";
            extraPreps.AllowNew = true;
            extraPreps.AllowRemove = true;
            lbExtras.DataSource = extraPreps;
            lbExtras.DisplayMember = "DisplayString";
        }

        private void processInput(string input)
        {
            lblError.Text = String.Empty;
            bool safeScan = Properties.Settings.Default.VerifyCollectionCodeInBarcode;
            if ((input.Length > 5 && input.Substring(0, 5).Equals("SHELF")) || (input.Length > 4 && input.Substring(0, 4).Equals("SLOC")))
            {
                try
                {
                    if (input.Substring(0, 4).Equals("SLOC"))
                    {
                        if (safeScan)
                        {
                            if (input.Substring(4, sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
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
                            if (input.Substring(5, sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
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
                        lblScanLoc.Text = "Storage Location set to " + sLocName + ".";
                        // Reset ListBoxes
                        unscannedPreps.Clear();
                        scannedPreps.Clear();
                        extraPreps.Clear();
                        // Populate Unscanned ListBox
                        List<Preparation> preps = sp.GetPreparationByStorageID(storageID);
                        foreach(Preparation preparation in preps)
                        {
                            unscannedPreps.Add(preparation);
                        }
                        lblUnscanned.Text = "Unscanned - " + unscannedPreps.Count.ToString();
                    }
                    else
                    {
                        storageID = -1;
                        lblError.Text = "Bad Storage Location " + input + ". Scan storage location label to begin.";
                    }
                }
                catch
                {
                    lblError.Text = "Bad Storage Location " + input + ". Scan a storage location label to begin.";
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
                    if (sp.IsValidPrepID(prepID))
                    {
                        bool found = false;
                        foreach(Preparation prep in unscannedPreps.ToList())
                        {
                            if(prep.PrepID == prepID)
                            {
                                scannedPreps.Add(prep);
                                lblScanned.Text = "Scanned - " + scannedPreps.Count.ToString();
                                unscannedPreps.Remove(prep);
                                lblUnscanned.Text = "Unscanned - " + unscannedPreps.Count.ToString();
                                found = true;
                                break;
                            }
                        }
                        if(!found)
                        {
                            if (!scannedPreps.Contains(new Preparation(prepID, String.Empty)) && !extraPreps.Contains(new Preparation(prepID, String.Empty)))
                            {
                                string displayMember = sp.GetPrepFullDetails(prepID);
                                extraPreps.Add(new Preparation(prepID, displayMember));
                                lblExtra.Text = "Extras - " + extraPreps.Count.ToString();
                            }
                            else
                            {
                                lblError.Text = prepID.ToString() + " already scanned";
                            }
                        }
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


        private void enter_key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processInput(tbInput.Text.Trim());
                tbInput.Clear();
            }
        }

        private void btnDownloadAuditLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.Title = "Save Audit History";
            saveFileDialog.FileName = "AuditLog-" + DateTime.Now.ToLocalTime().ToString("yyyyMMddhhmm") + "-" + sp.AgentName + "-" + sp.Database + ".txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName)) 
                {
                    writer.WriteLine("Audit Log for " + sp.GetStorageIDName(storageID) + "\n");
                    writer.WriteLine("Exported " + DateTime.Now.ToLocalTime().ToString("yyyyMMddhhmm") + "\n");
                    writer.WriteLine("\nUnscanned Preps...");
                    foreach(Preparation prep in unscannedPreps)
                    {
                        writer.WriteLine(prep.DisplayString);
                    }
                    writer.WriteLine("\nScanned...");
                    foreach(Preparation prep in scannedPreps)
                    {
                        writer.WriteLine(prep.DisplayString);
                    }
                    writer.WriteLine("\nScanned but shouldn't be on this SLOC...");
                    foreach(Preparation prep in extraPreps)
                    {
                        writer.WriteLine(prep.DisplayString);
                    }
                }
            }
        }
    }
}
