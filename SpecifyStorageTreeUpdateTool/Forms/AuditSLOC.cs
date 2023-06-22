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
                        // Populate Unscanned ListBox
                        List<Preparation> preps = sp.GetPreparationByStorageID(storageID);
                        foreach(Preparation preparation in preps)
                        {
                            unscannedPreps.Add(preparation);
                        }
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
                       /* if(unscannedPreps.Contains(prepID.ToString()))
                        {

                        }*/
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
    }
}
