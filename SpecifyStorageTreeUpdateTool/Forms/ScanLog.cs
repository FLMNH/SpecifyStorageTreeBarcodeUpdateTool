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
        }
    }
}
