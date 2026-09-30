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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COScan));
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblScanCount = new System.Windows.Forms.Label();
            this.lblCOIDField = new System.Windows.Forms.Label();
            this.cmbCOIDField = new System.Windows.Forms.ComboBox();
            this.lblPrepType = new System.Windows.Forms.Label();
            this.cmbPrepType = new System.Windows.Forms.ComboBox();
            this.ckbxCreatePrep = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSLOCCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOutput
            // 
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(0, 442);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(6);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(2556, 1045);
            this.tbOutput.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(64, 38);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHeader.MaximumSize = new System.Drawing.Size(2000, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1941, 96);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "This form enables scanning of Collection Object Barcodes and setting the Storage " +
    "Tree location of that Collection Object\'s preparation.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1162, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scan the Stationary Location (SLOC) or Moveable Location (MLOC)";
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(74, 252);
            this.tbInput.Margin = new System.Windows.Forms.Padding(6);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(648, 44);
            this.tbInput.TabIndex = 5;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(66, 360);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(227, 37);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Parent Not Set";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(278, 429);
            this.lblError.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 25);
            this.lblError.TabIndex = 7;
            this.lblError.Visible = false;
            // 
            // lblScanCount
            // 
            this.lblScanCount.AutoSize = true;
            this.lblScanCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanCount.Location = new System.Drawing.Point(1836, 165);
            this.lblScanCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblScanCount.Name = "lblScanCount";
            this.lblScanCount.Size = new System.Drawing.Size(203, 37);
            this.lblScanCount.TabIndex = 16;
            this.lblScanCount.Text = "Scan Count: ";
            // 
            // lblCOIDField
            // 
            this.lblCOIDField.AutoSize = true;
            this.lblCOIDField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCOIDField.Location = new System.Drawing.Point(1322, 229);
            this.lblCOIDField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCOIDField.Name = "lblCOIDField";
            this.lblCOIDField.Size = new System.Drawing.Size(388, 37);
            this.lblCOIDField.TabIndex = 17;
            this.lblCOIDField.Text = "Collection Object Identifier";
            // 
            // cmbCOIDField
            // 
            this.cmbCOIDField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOIDField.FormattingEnabled = true;
            this.cmbCOIDField.Location = new System.Drawing.Point(1330, 275);
            this.cmbCOIDField.Margin = new System.Windows.Forms.Padding(6);
            this.cmbCOIDField.Name = "cmbCOIDField";
            this.cmbCOIDField.Size = new System.Drawing.Size(376, 33);
            this.cmbCOIDField.TabIndex = 18;
            // 
            // lblPrepType
            // 
            this.lblPrepType.AutoSize = true;
            this.lblPrepType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrepType.Location = new System.Drawing.Point(1836, 229);
            this.lblPrepType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPrepType.Name = "lblPrepType";
            this.lblPrepType.Size = new System.Drawing.Size(154, 37);
            this.lblPrepType.TabIndex = 19;
            this.lblPrepType.Text = "PrepType";
            // 
            // cmbPrepType
            // 
            this.cmbPrepType.FormattingEnabled = true;
            this.cmbPrepType.Location = new System.Drawing.Point(1844, 275);
            this.cmbPrepType.Margin = new System.Windows.Forms.Padding(6);
            this.cmbPrepType.Name = "cmbPrepType";
            this.cmbPrepType.Size = new System.Drawing.Size(334, 33);
            this.cmbPrepType.TabIndex = 20;
            // 
            // ckbxCreatePrep
            // 
            this.ckbxCreatePrep.AutoSize = true;
            this.ckbxCreatePrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbxCreatePrep.Location = new System.Drawing.Point(1844, 359);
            this.ckbxCreatePrep.Margin = new System.Windows.Forms.Padding(6);
            this.ckbxCreatePrep.Name = "ckbxCreatePrep";
            this.ckbxCreatePrep.Size = new System.Drawing.Size(466, 41);
            this.ckbxCreatePrep.TabIndex = 22;
            this.ckbxCreatePrep.Text = "Create Prep If No Preps Exist";
            this.ckbxCreatePrep.UseVisualStyleBackColor = true;
            this.ckbxCreatePrep.CheckedChanged += new System.EventHandler(this.ckbxCreatePrep_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2556, 442);
            this.panel1.TabIndex = 0;
            // 
            // lblSLOCCount
            // 
            this.lblSLOCCount.AutoSize = true;
            this.lblSLOCCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLOCCount.Location = new System.Drawing.Point(1314, 165);
            this.lblSLOCCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSLOCCount.Name = "lblSLOCCount";
            this.lblSLOCCount.Size = new System.Drawing.Size(318, 37);
            this.lblSLOCCount.TabIndex = 15;
            this.lblSLOCCount.Text = "SLOC/MLOC Count: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(2245, 252);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 87);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // COScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2556, 1487);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "COScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Collection Object Scan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblScanCount;
        private System.Windows.Forms.Label lblCOIDField;
        private System.Windows.Forms.ComboBox cmbCOIDField;
        private System.Windows.Forms.Label lblPrepType;
        private System.Windows.Forms.ComboBox cmbPrepType;
        private System.Windows.Forms.CheckBox ckbxCreatePrep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSLOCCount;
        private System.Windows.Forms.Button button1;
    }
}