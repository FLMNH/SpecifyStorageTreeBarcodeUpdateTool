using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecifyStorageTreeUpdateTool.Forms
{
    public partial class MoveLocation : Form
    {
        private int storageID = -1;
        private SpecifyTools sp;

        public MoveLocation()
        {
            InitializeComponent();
        }
        public MoveLocation(SpecifyTools sp)
        {
            InitializeComponent();
            this.sp = sp;
        }

        private void enter_key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processInput(tbInput.Text.Trim());
                tbInput.Clear();
            }
        }

        private void processInput(string input)
        {
            bool safeScan = Properties.Settings.Default.VerifyCollectionCodeInBarcode;
            if ((input.Length > 5 && input.Substring(0, 4).Equals("SHELF")) || (input.Length > 5 && input.Substring(0, 4).Equals("SLOC")))
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
                        tbOutput.AppendText("Parent set to " + sLocName + ".");
                        tbOutput.AppendText(Environment.NewLine);
                        lblParent.Text = "Parent: " + sLocName;
                    }
                    else
                    {
                        storageID = -1;
                        tbOutput.AppendText("Bad Storage Location " + input + ". Scan storage location label to begin.");
                        tbOutput.AppendText(Environment.NewLine);
                    }
                }
                catch
                {
                    tbOutput.AppendText("Bad Storage Location " + input + ". Scan a storage location label to begin.");
                }
            }
            else if (storageID != -1 && input.Length > 5 && input.Substring(0,4).Equals("MLOC")) 
            {
                try
                {
                    int mlocID = 0;
                    if (safeScan)
                    {
                        if (input.Substring(4, sp.CollectionName.Length).ToUpper().Equals(sp.CollectionName.ToUpper()))
                        {
                            mlocID = int.Parse(input.Substring(4 + sp.CollectionName.Length));
                        }
                    }
                    else
                    {
                        mlocID = int.Parse(input.Substring(4));
                    }
                    if (sp.IsValidStorageID(mlocID))
                    {                        
                        if (sp.UpdateStorageNodeParentID(mlocID, storageID))
                        {  
                            tbOutput.AppendText(sp.GetStorageIDName(mlocID) + " parent set to " + sp.GetStorageIDName(storageID));
                            tbOutput.AppendText(Environment.NewLine);
                        }
                        else
                        {
                            tbOutput.AppendText("Failed to update " + sp.GetStorageIDName(mlocID) + " parent.");
                            tbOutput.AppendText(Environment.NewLine);
                        }
                    }
                    else
                    {
                        tbOutput.AppendText(input + " is not a valid storage location.");
                        tbOutput.AppendText(Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    tbOutput.AppendText(input + " not a value prep ID");
                }
            }
        }
    }
}
