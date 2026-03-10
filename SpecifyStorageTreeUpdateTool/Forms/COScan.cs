using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SpecifyStorageTreeUpdateTool.Forms
{
    public partial class COScan : Form
    {
        private int storageID = -1;
        private SpecifyTools sp;
        private int scanCount;
        private int slocCount = -1;

        public COScan()
        {
            InitializeComponent();
        }

        public COScan(SpecifyTools sp)
        {
            InitializeComponent();
            this.sp = sp;
            tbOutput.AppendText("Start " + sp.AgentName + " using " + sp.Database + " on " + sp.Server + " at " + DateTime.Now.ToString() + ".");
            tbOutput.AppendText(Environment.NewLine);
            cmbCOIDField.DataSource = sp.GetCOFieldNames();
            cmbPrepType.DataSource = sp.GetCmbPrepTypes();
            cmbPrepType.DisplayMember = "Value";
            cmbPrepType.ValueMember = "Key";
            tbInput.Focus();
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
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
            if ((input.Length > 5 && input.Substring(0, 5).Equals("SHELF")) || (input.Length > 4 && input.Substring(0, 4).Equals("SLOC")) || (input.Length > 4 && input.Substring(0, 4).Equals("MLOC")))
            {
                try
                {
                    if (input.Substring(0, 4).Equals("SLOC") || input.Substring(0, 4).Equals("MLOC"))
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
                        slocCount = sp.GetSLOCCount(storageID);
                        lblStatus.Text = "Storage Location set to " + sLocName + ".";
                        tbOutput.AppendText("Storage Location set to " + sLocName + ".");
                        tbOutput.AppendText(Environment.NewLine);
                        lblSLOCCount.Text = slocCount.ToString();
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
            else if (input.Length > 4 && input.Substring(0, 3).Equals("CID"))
            {
                string containerID = "";
                if (safeScan)
                {
                    if (input.Substring(3, sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
                    {
                        containerID = input.Substring(3 + sp.CollectionName.Length);
                    }
                }
                else
                {
                    containerID = input.Substring(3);

                }
                if (storageID != -1 && sp.IsValidContainerID(containerID))
                {
                    tbOutput.AppendText("Begin processing Container Location: " + containerID + ".");
                    tbOutput.AppendText(Environment.NewLine);
                    List<int> prepIDs = sp.GetContainerLocationPrepIDs(containerID);
                    foreach (int prepID in prepIDs)
                    {
                        if (sp.UpdatePreparationStorageID(prepID, storageID))
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
                tbInput.Focus();
                try
                {
                    // 1) Scan in the CollectionObject identifier
                    // 2) If PrepType exists, and CreateOnly bool is True, create a new Prep of PrepType
                    // else: create New Prep of selected PrepType
                    int prepID = 0;

                    if (input.Length > 0)
                    {
                        int CollectionObjectID = sp.GetCOIDbyField(cmbCOIDField.Text, input);
                        if (ckbxCreatePrep.Checked)
                        {
                            KeyValuePair<int, string> selectedKvp = (KeyValuePair<int, string>)cmbPrepType.SelectedItem;
                            prepID = sp.CreatePrep(CollectionObjectID, selectedKvp.Key);
                        }
                        else if(!ckbxCreatePrep.Checked)
                        {
                            KeyValuePair<int, string> selectedKvp = (KeyValuePair<int, string>)cmbPrepType.SelectedItem;
                            prepID = sp.GetCOFirstPrepType(CollectionObjectID, selectedKvp.Key);
                            if (prepID == 0)
                            {
                                lblError.Text = $"Collection Object ID {CollectionObjectID} has no preps of type {selectedKvp.Value}";
                            }
                        }
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

        
    }
}
