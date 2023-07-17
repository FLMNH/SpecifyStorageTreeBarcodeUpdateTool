namespace SpecifyStorageTreeUpdateTool.Forms
{
    partial class AuditSLOC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditSLOC));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDownloadAuditLog = new System.Windows.Forms.Button();
            this.lblExtra = new System.Windows.Forms.Label();
            this.lblScanned = new System.Windows.Forms.Label();
            this.lblUnscanned = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lblScanLoc = new System.Windows.Forms.Label();
            this.splitContainerListBoxParent = new System.Windows.Forms.SplitContainer();
            this.lbUnscanned = new System.Windows.Forms.ListBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbScanned = new System.Windows.Forms.ListBox();
            this.lbExtras = new System.Windows.Forms.ListBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainerBottomParent = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerListBoxParent)).BeginInit();
            this.splitContainerListBoxParent.Panel1.SuspendLayout();
            this.splitContainerListBoxParent.Panel2.SuspendLayout();
            this.splitContainerListBoxParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottomParent)).BeginInit();
            this.splitContainerBottomParent.Panel1.SuspendLayout();
            this.splitContainerBottomParent.Panel2.SuspendLayout();
            this.splitContainerBottomParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDownloadAuditLog);
            this.splitContainer1.Panel1.Controls.Add(this.lblError);
            this.splitContainer1.Panel1.Controls.Add(this.tbInput);
            this.splitContainer1.Panel1.Controls.Add(this.lblScanLoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerBottomParent);
            this.splitContainer1.Size = new System.Drawing.Size(1395, 617);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnDownloadAuditLog
            // 
            this.btnDownloadAuditLog.BackColor = System.Drawing.SystemColors.Control;
            this.btnDownloadAuditLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDownloadAuditLog.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDownloadAuditLog.FlatAppearance.BorderSize = 0;
            this.btnDownloadAuditLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDownloadAuditLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadAuditLog.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadAuditLog.Image")));
            this.btnDownloadAuditLog.Location = new System.Drawing.Point(672, 39);
            this.btnDownloadAuditLog.Name = "btnDownloadAuditLog";
            this.btnDownloadAuditLog.Size = new System.Drawing.Size(43, 45);
            this.btnDownloadAuditLog.TabIndex = 10;
            this.btnDownloadAuditLog.UseVisualStyleBackColor = false;
            this.btnDownloadAuditLog.Click += new System.EventHandler(this.btnDownloadAuditLog_Click);
            // 
            // lblExtra
            // 
            this.lblExtra.AutoSize = true;
            this.lblExtra.Location = new System.Drawing.Point(12, 408);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(44, 16);
            this.lblExtra.TabIndex = 6;
            this.lblExtra.Text = "Extras";
            // 
            // lblScanned
            // 
            this.lblScanned.AutoSize = true;
            this.lblScanned.Location = new System.Drawing.Point(12, 193);
            this.lblScanned.Name = "lblScanned";
            this.lblScanned.Size = new System.Drawing.Size(61, 16);
            this.lblScanned.TabIndex = 5;
            this.lblScanned.Text = "Scanned";
            // 
            // lblUnscanned
            // 
            this.lblUnscanned.AutoSize = true;
            this.lblUnscanned.Location = new System.Drawing.Point(12, 57);
            this.lblUnscanned.Name = "lblUnscanned";
            this.lblUnscanned.Size = new System.Drawing.Size(76, 16);
            this.lblUnscanned.TabIndex = 4;
            this.lblUnscanned.Text = "Unscanned";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(16, 115);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 3;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(16, 50);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(263, 22);
            this.tbInput.TabIndex = 2;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_key_down);
            // 
            // lblScanLoc
            // 
            this.lblScanLoc.AutoSize = true;
            this.lblScanLoc.Location = new System.Drawing.Point(13, 22);
            this.lblScanLoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScanLoc.Name = "lblScanLoc";
            this.lblScanLoc.Size = new System.Drawing.Size(197, 16);
            this.lblScanLoc.TabIndex = 0;
            this.lblScanLoc.Text = "Scan a storage location to audit.";
            // 
            // splitContainerListBoxParent
            // 
            this.splitContainerListBoxParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListBoxParent.Location = new System.Drawing.Point(0, 0);
            this.splitContainerListBoxParent.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerListBoxParent.Name = "splitContainerListBoxParent";
            this.splitContainerListBoxParent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerListBoxParent.Panel1
            // 
            this.splitContainerListBoxParent.Panel1.Controls.Add(this.lbUnscanned);
            // 
            // splitContainerListBoxParent.Panel2
            // 
            this.splitContainerListBoxParent.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainerListBoxParent.Size = new System.Drawing.Size(1253, 490);
            this.splitContainerListBoxParent.SplitterDistance = 136;
            this.splitContainerListBoxParent.SplitterWidth = 5;
            this.splitContainerListBoxParent.TabIndex = 0;
            // 
            // lbUnscanned
            // 
            this.lbUnscanned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnscanned.FormattingEnabled = true;
            this.lbUnscanned.HorizontalScrollbar = true;
            this.lbUnscanned.ItemHeight = 16;
            this.lbUnscanned.Location = new System.Drawing.Point(0, 0);
            this.lbUnscanned.Name = "lbUnscanned";
            this.lbUnscanned.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbUnscanned.Size = new System.Drawing.Size(1253, 136);
            this.lbUnscanned.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbScanned);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lbExtras);
            this.splitContainer3.Size = new System.Drawing.Size(1253, 349);
            this.splitContainer3.SplitterDistance = 206;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbScanned
            // 
            this.lbScanned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScanned.FormattingEnabled = true;
            this.lbScanned.HorizontalScrollbar = true;
            this.lbScanned.ItemHeight = 16;
            this.lbScanned.Location = new System.Drawing.Point(0, 0);
            this.lbScanned.Name = "lbScanned";
            this.lbScanned.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbScanned.Size = new System.Drawing.Size(1253, 206);
            this.lbScanned.TabIndex = 0;
            // 
            // lbExtras
            // 
            this.lbExtras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbExtras.FormattingEnabled = true;
            this.lbExtras.HorizontalScrollbar = true;
            this.lbExtras.ItemHeight = 16;
            this.lbExtras.Location = new System.Drawing.Point(0, 0);
            this.lbExtras.Name = "lbExtras";
            this.lbExtras.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbExtras.Size = new System.Drawing.Size(1253, 138);
            this.lbExtras.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1395, 617);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1395, 642);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // splitContainerBottomParent
            // 
            this.splitContainerBottomParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBottomParent.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBottomParent.Name = "splitContainerBottomParent";
            // 
            // splitContainerBottomParent.Panel1
            // 
            this.splitContainerBottomParent.Panel1.Controls.Add(this.lblUnscanned);
            this.splitContainerBottomParent.Panel1.Controls.Add(this.lblExtra);
            this.splitContainerBottomParent.Panel1.Controls.Add(this.lblScanned);
            // 
            // splitContainerBottomParent.Panel2
            // 
            this.splitContainerBottomParent.Panel2.Controls.Add(this.splitContainerListBoxParent);
            this.splitContainerBottomParent.Size = new System.Drawing.Size(1395, 490);
            this.splitContainerBottomParent.SplitterDistance = 138;
            this.splitContainerBottomParent.TabIndex = 1;
            // 
            // AuditSLOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 642);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AuditSLOC";
            this.Text = "Audit Storage Location";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerListBoxParent.Panel1.ResumeLayout(false);
            this.splitContainerListBoxParent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerListBoxParent)).EndInit();
            this.splitContainerListBoxParent.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainerBottomParent.Panel1.ResumeLayout(false);
            this.splitContainerBottomParent.Panel1.PerformLayout();
            this.splitContainerBottomParent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottomParent)).EndInit();
            this.splitContainerBottomParent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainerListBoxParent;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lblScanLoc;
        private System.Windows.Forms.ListBox lbUnscanned;
        private System.Windows.Forms.ListBox lbScanned;
        private System.Windows.Forms.ListBox lbExtras;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.Label lblScanned;
        private System.Windows.Forms.Label lblUnscanned;
        private System.Windows.Forms.Button btnDownloadAuditLog;
        private System.Windows.Forms.SplitContainer splitContainerBottomParent;
    }
}