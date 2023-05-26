namespace SpecifyStorageTreeUpdateTool
{
    partial class Scanning
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scanning));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScanHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePrepBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStorageBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCollection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblSLOCCount = new System.Windows.Forms.Label();
            this.lblSLOCCountLabel = new System.Windows.Forms.Label();
            this.lblScanCount = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.auditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditSLOCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.auditToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveScanHistoryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveScanHistoryToolStripMenuItem
            // 
            this.saveScanHistoryToolStripMenuItem.Name = "saveScanHistoryToolStripMenuItem";
            this.saveScanHistoryToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveScanHistoryToolStripMenuItem.Text = "Save Scan History";
            this.saveScanHistoryToolStripMenuItem.Click += new System.EventHandler(this.saveScanHistoryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.updatePrepBarcodesToolStripMenuItem,
            this.updateStorageBarcodesToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // updatePrepBarcodesToolStripMenuItem
            // 
            this.updatePrepBarcodesToolStripMenuItem.Name = "updatePrepBarcodesToolStripMenuItem";
            this.updatePrepBarcodesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.updatePrepBarcodesToolStripMenuItem.Text = "Update Prep Barcodes";
            this.updatePrepBarcodesToolStripMenuItem.Click += new System.EventHandler(this.updatePrepBarcodesToolStripMenuItem_Click);
            // 
            // updateStorageBarcodesToolStripMenuItem
            // 
            this.updateStorageBarcodesToolStripMenuItem.Name = "updateStorageBarcodesToolStripMenuItem";
            this.updateStorageBarcodesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.updateStorageBarcodesToolStripMenuItem.Text = "UpdateStorage Barcodes";
            this.updateStorageBarcodesToolStripMenuItem.Click += new System.EventHandler(this.updateStorageBarcodesToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanLogToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // scanLogToolStripMenuItem
            // 
            this.scanLogToolStripMenuItem.Name = "scanLogToolStripMenuItem";
            this.scanLogToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.scanLogToolStripMenuItem.Text = "Scan Log";
            this.scanLogToolStripMenuItem.Visible = false;
            this.scanLogToolStripMenuItem.Click += new System.EventHandler(this.scanLogToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(0, 0);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(1244, 672);
            this.tbOutput.TabIndex = 7;
            this.toolTip1.SetToolTip(this.tbOutput, "Scan History");
            this.tbOutput.WordWrap = false;
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(28, 113);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(335, 26);
            this.tbInput.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbInput, "Scan a Barcode");
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterKey_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusSpacer,
            this.toolStripStatusUserName,
            this.toolStripStatusLabelCollection,
            this.toolStripStatusDatabase,
            this.toolStripStatusServer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 921);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 24);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusSpacer
            // 
            this.toolStripStatusSpacer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusSpacer.Name = "toolStripStatusSpacer";
            this.toolStripStatusSpacer.Size = new System.Drawing.Size(996, 19);
            this.toolStripStatusSpacer.Spring = true;
            this.toolStripStatusSpacer.Text = "    ";
            this.toolStripStatusSpacer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusUserName
            // 
            this.toolStripStatusUserName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusUserName.Name = "toolStripStatusUserName";
            this.toolStripStatusUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusUserName.Size = new System.Drawing.Size(66, 19);
            this.toolStripStatusUserName.Text = "UserName";
            this.toolStripStatusUserName.ToolTipText = "Current User Name";
            // 
            // toolStripStatusLabelCollection
            // 
            this.toolStripStatusLabelCollection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelCollection.Name = "toolStripStatusLabelCollection";
            this.toolStripStatusLabelCollection.Size = new System.Drawing.Size(65, 19);
            this.toolStripStatusLabelCollection.Text = "Collection";
            // 
            // toolStripStatusDatabase
            // 
            this.toolStripStatusDatabase.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusDatabase.Name = "toolStripStatusDatabase";
            this.toolStripStatusDatabase.Size = new System.Drawing.Size(59, 19);
            this.toolStripStatusDatabase.Text = "Database";
            // 
            // toolStripStatusServer
            // 
            this.toolStripStatusServer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusServer.Name = "toolStripStatusServer";
            this.toolStripStatusServer.Size = new System.Drawing.Size(43, 19);
            this.toolStripStatusServer.Text = "Server";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(369, 119);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(674, 16);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "Storage Location labels are storage.StorageID with a prefix of \"SLOC\". Prep label" +
    "s are preparation.PreparationID";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(28, 77);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(287, 20);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Scan a Storage Location label to begin.";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lblSLOCCount);
            this.splitContainer.Panel1.Controls.Add(this.lblSLOCCountLabel);
            this.splitContainer.Panel1.Controls.Add(this.lblScanCount);
            this.splitContainer.Panel1.Controls.Add(this.lblError);
            this.splitContainer.Panel1.Controls.Add(this.button1);
            this.splitContainer.Panel1.Controls.Add(this.lblInfo);
            this.splitContainer.Panel1.Controls.Add(this.lblTitle);
            this.splitContainer.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer.Panel1.Controls.Add(this.tbInput);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbOutput);
            this.splitContainer.Size = new System.Drawing.Size(1244, 897);
            this.splitContainer.SplitterDistance = 221;
            this.splitContainer.TabIndex = 11;
            // 
            // lblSLOCCount
            // 
            this.lblSLOCCount.AutoSize = true;
            this.lblSLOCCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLOCCount.Location = new System.Drawing.Point(767, 29);
            this.lblSLOCCount.Name = "lblSLOCCount";
            this.lblSLOCCount.Size = new System.Drawing.Size(0, 20);
            this.lblSLOCCount.TabIndex = 15;
            // 
            // lblSLOCCountLabel
            // 
            this.lblSLOCCountLabel.AutoSize = true;
            this.lblSLOCCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLOCCountLabel.Location = new System.Drawing.Point(654, 29);
            this.lblSLOCCountLabel.Name = "lblSLOCCountLabel";
            this.lblSLOCCountLabel.Size = new System.Drawing.Size(107, 20);
            this.lblSLOCCountLabel.TabIndex = 14;
            this.lblSLOCCountLabel.Text = "SLOC Count: ";
            // 
            // lblScanCount
            // 
            this.lblScanCount.AutoSize = true;
            this.lblScanCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanCount.Location = new System.Drawing.Point(900, 29);
            this.lblScanCount.Name = "lblScanCount";
            this.lblScanCount.Size = new System.Drawing.Size(101, 20);
            this.lblScanCount.TabIndex = 13;
            this.lblScanCount.Text = "Scan Count: ";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.IndianRed;
            this.lblError.Location = new System.Drawing.Point(552, 29);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(21, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(499, 37);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Specify Storage Tree Update Tool";
            // 
            // auditToolStripMenuItem
            // 
            this.auditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auditSLOCToolStripMenuItem});
            this.auditToolStripMenuItem.Name = "auditToolStripMenuItem";
            this.auditToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.auditToolStripMenuItem.Text = "Audit";
            // 
            // auditSLOCToolStripMenuItem
            // 
            this.auditSLOCToolStripMenuItem.Name = "auditSLOCToolStripMenuItem";
            this.auditSLOCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.auditSLOCToolStripMenuItem.Text = "Audit SLOC";
            this.auditSLOCToolStripMenuItem.Click += new System.EventHandler(this.auditSLOCToolStripMenuItem_Click);
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
            this.button1.Location = new System.Drawing.Point(1042, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 45);
            this.button1.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button1, "Save Output to File");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Scanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1244, 945);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Scanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specify Storage Tree Update Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveScanHistoryToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSpacer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDatabase;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusServer;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.Label lblScanCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCollection;
        private System.Windows.Forms.ToolStripMenuItem updatePrepBarcodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStorageBarcodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanLogToolStripMenuItem;
        private System.Windows.Forms.Label lblSLOCCountLabel;
        private System.Windows.Forms.Label lblSLOCCount;
        private System.Windows.Forms.ToolStripMenuItem auditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditSLOCToolStripMenuItem;
    }
}

