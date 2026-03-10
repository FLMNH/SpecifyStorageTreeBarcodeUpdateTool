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
            this.lblScanCount = new System.Windows.Forms.Label();
            this.lblSLOCCount = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lblCOIDField = new System.Windows.Forms.Label();
            this.cmbCOIDField = new System.Windows.Forms.ComboBox();
            this.lblPrepType = new System.Windows.Forms.Label();
            this.cmbPrepType = new System.Windows.Forms.ComboBox();
            this.ckbxCreatePrep = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckbxCreatePrep);
            this.panel1.Controls.Add(this.cmbPrepType);
            this.panel1.Controls.Add(this.lblPrepType);
            this.panel1.Controls.Add(this.cmbCOIDField);
            this.panel1.Controls.Add(this.lblCOIDField);
            this.panel1.Controls.Add(this.lblScanCount);
            this.panel1.Controls.Add(this.lblSLOCCount);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.tbInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 255);
            this.panel1.TabIndex = 0;
            // 
            // lblScanCount
            // 
            this.lblScanCount.AutoSize = true;
            this.lblScanCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanCount.Location = new System.Drawing.Point(1023, 86);
            this.lblScanCount.Name = "lblScanCount";
            this.lblScanCount.Size = new System.Drawing.Size(101, 20);
            this.lblScanCount.TabIndex = 16;
            this.lblScanCount.Text = "Scan Count: ";
            // 
            // lblSLOCCount
            // 
            this.lblSLOCCount.AutoSize = true;
            this.lblSLOCCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLOCCount.Location = new System.Drawing.Point(762, 86);
            this.lblSLOCCount.Name = "lblSLOCCount";
            this.lblSLOCCount.Size = new System.Drawing.Size(107, 20);
            this.lblSLOCCount.TabIndex = 15;
            this.lblSLOCCount.Text = "SLOC Count: ";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(139, 223);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 7;
            this.lblError.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(138, 187);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(114, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Parent Not Set";
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(142, 131);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(326, 26);
            this.tbInput.TabIndex = 5;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
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
            // tbOutput
            // 
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(0, 255);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(1278, 518);
            this.tbOutput.TabIndex = 1;
            // 
            // lblCOIDField
            // 
            this.lblCOIDField.AutoSize = true;
            this.lblCOIDField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCOIDField.Location = new System.Drawing.Point(766, 119);
            this.lblCOIDField.Name = "lblCOIDField";
            this.lblCOIDField.Size = new System.Drawing.Size(194, 20);
            this.lblCOIDField.TabIndex = 17;
            this.lblCOIDField.Text = "Collection Object Identifier";
            // 
            // cmbCOIDField
            // 
            this.cmbCOIDField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOIDField.FormattingEnabled = true;
            this.cmbCOIDField.Location = new System.Drawing.Point(770, 143);
            this.cmbCOIDField.Name = "cmbCOIDField";
            this.cmbCOIDField.Size = new System.Drawing.Size(190, 21);
            this.cmbCOIDField.TabIndex = 18;
            // 
            // lblPrepType
            // 
            this.lblPrepType.AutoSize = true;
            this.lblPrepType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrepType.Location = new System.Drawing.Point(1023, 119);
            this.lblPrepType.Name = "lblPrepType";
            this.lblPrepType.Size = new System.Drawing.Size(76, 20);
            this.lblPrepType.TabIndex = 19;
            this.lblPrepType.Text = "PrepType";
            // 
            // cmbPrepType
            // 
            this.cmbPrepType.FormattingEnabled = true;
            this.cmbPrepType.Location = new System.Drawing.Point(1027, 143);
            this.cmbPrepType.Name = "cmbPrepType";
            this.cmbPrepType.Size = new System.Drawing.Size(169, 21);
            this.cmbPrepType.TabIndex = 20;
            // 
            // ckbxCreatePrep
            // 
            this.ckbxCreatePrep.AutoSize = true;
            this.ckbxCreatePrep.Checked = true;
            this.ckbxCreatePrep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbxCreatePrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbxCreatePrep.Location = new System.Drawing.Point(1027, 187);
            this.ckbxCreatePrep.Name = "ckbxCreatePrep";
            this.ckbxCreatePrep.Size = new System.Drawing.Size(148, 24);
            this.ckbxCreatePrep.TabIndex = 22;
            this.ckbxCreatePrep.Text = "Create Prep Only";
            this.ckbxCreatePrep.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblSLOCCount;
        private System.Windows.Forms.Label lblScanCount;
        private System.Windows.Forms.Label lblCOIDField;
        private System.Windows.Forms.ComboBox cmbCOIDField;
        private System.Windows.Forms.Label lblPrepType;
        private System.Windows.Forms.ComboBox cmbPrepType;
        private System.Windows.Forms.CheckBox ckbxCreatePrep;
    }
}