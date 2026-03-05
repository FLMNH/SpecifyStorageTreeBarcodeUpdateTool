namespace SpecifyStorageTreeUpdateTool.Forms
{
    partial class COScan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lblParent = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblParent);
            this.panel1.Controls.Add(this.tbInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 255);
            this.panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(137, 20);
            this.lblHeader.MaximumSize = new System.Drawing.Size(1000, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(937, 75);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "This form enables scanning of Colleciton Object Barcodes and setting the Storage " +
    "Tree parent of that Collection Object\'s preparation.\r\n\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scan the Stationary Location (SLOC) or Moveable Location (MLOC)";
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(142, 131);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(326, 26);
            this.tbInput.TabIndex = 5;
            this.tbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyUp);
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParent.Location = new System.Drawing.Point(138, 187);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(114, 20);
            this.lblParent.TabIndex = 6;
            this.lblParent.Text = "Parent Not Set";
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(0, 261);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(1278, 512);
            this.tbOutput.TabIndex = 1;
            // 
            // COScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 773);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.panel1);
            this.Name = "COScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Collection Object Scan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox tbOutput;
    }
}