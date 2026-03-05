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
            tbInput.Focus();
        }

        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processInput(tbInput.Text.Trim());
                tbInput.Clear();
            }
        }

        private void processInput(string input)
        {

        }
    }
}
