namespace SpecifyStorageTreeUpdateTool.Forms
{
    partial class ConfigForm
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
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.enableAuditLogCheckbox = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.MasterUserNameLabel = new System.Windows.Forms.Label();
            this.MasterPasswordLabel = new System.Windows.Forms.Label();
            this.MasterUserNameTextBox = new System.Windows.Forms.TextBox();
            this.MasterPasswordTextBox = new System.Windows.Forms.TextBox();
            this.CreateTableEnableLogginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(40, 28);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(230, 37);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Config Options";
            // 
            // enableAuditLogCheckbox
            // 
            this.enableAuditLogCheckbox.AutoSize = true;
            this.enableAuditLogCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableAuditLogCheckbox.Location = new System.Drawing.Point(47, 85);
            this.enableAuditLogCheckbox.Name = "enableAuditLogCheckbox";
            this.enableAuditLogCheckbox.Size = new System.Drawing.Size(316, 28);
            this.enableAuditLogCheckbox.TabIndex = 1;
            this.enableAuditLogCheckbox.Text = "Enable Scan Logging for Analytics";
            this.enableAuditLogCheckbox.UseVisualStyleBackColor = true;
            this.enableAuditLogCheckbox.CheckedChanged += new System.EventHandler(this.enableAuditLogCheckbox_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(341, 303);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 39);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MasterUserNameLabel
            // 
            this.MasterUserNameLabel.AutoSize = true;
            this.MasterUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasterUserNameLabel.Location = new System.Drawing.Point(47, 142);
            this.MasterUserNameLabel.Name = "MasterUserNameLabel";
            this.MasterUserNameLabel.Size = new System.Drawing.Size(158, 24);
            this.MasterUserNameLabel.TabIndex = 3;
            this.MasterUserNameLabel.Text = "Master Username";
            this.MasterUserNameLabel.Visible = false;
            // 
            // MasterPasswordLabel
            // 
            this.MasterPasswordLabel.AutoSize = true;
            this.MasterPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasterPasswordLabel.Location = new System.Drawing.Point(47, 189);
            this.MasterPasswordLabel.Name = "MasterPasswordLabel";
            this.MasterPasswordLabel.Size = new System.Drawing.Size(153, 24);
            this.MasterPasswordLabel.TabIndex = 4;
            this.MasterPasswordLabel.Text = "Master Password";
            this.MasterPasswordLabel.Visible = false;
            // 
            // MasterUserNameTextBox
            // 
            this.MasterUserNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasterUserNameTextBox.Location = new System.Drawing.Point(222, 140);
            this.MasterUserNameTextBox.Name = "MasterUserNameTextBox";
            this.MasterUserNameTextBox.Size = new System.Drawing.Size(224, 29);
            this.MasterUserNameTextBox.TabIndex = 5;
            this.MasterUserNameTextBox.Visible = false;
            // 
            // MasterPasswordTextBox
            // 
            this.MasterPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasterPasswordTextBox.Location = new System.Drawing.Point(222, 187);
            this.MasterPasswordTextBox.Name = "MasterPasswordTextBox";
            this.MasterPasswordTextBox.Size = new System.Drawing.Size(224, 29);
            this.MasterPasswordTextBox.TabIndex = 6;
            this.MasterPasswordTextBox.UseSystemPasswordChar = true;
            this.MasterPasswordTextBox.Visible = false;
            // 
            // CreateTableEnableLogginButton
            // 
            this.CreateTableEnableLogginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTableEnableLogginButton.Location = new System.Drawing.Point(69, 236);
            this.CreateTableEnableLogginButton.Name = "CreateTableEnableLogginButton";
            this.CreateTableEnableLogginButton.Size = new System.Drawing.Size(377, 39);
            this.CreateTableEnableLogginButton.TabIndex = 7;
            this.CreateTableEnableLogginButton.Text = "Create Audit Table and Enable Logging";
            this.CreateTableEnableLogginButton.UseVisualStyleBackColor = true;
            this.CreateTableEnableLogginButton.Visible = false;
            this.CreateTableEnableLogginButton.Click += new System.EventHandler(this.CreateTableEnableLogginButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 437);
            this.Controls.Add(this.CreateTableEnableLogginButton);
            this.Controls.Add(this.MasterPasswordTextBox);
            this.Controls.Add(this.MasterUserNameTextBox);
            this.Controls.Add(this.MasterPasswordLabel);
            this.Controls.Add(this.MasterUserNameLabel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.enableAuditLogCheckbox);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "ConfigForm";
            this.Text = "Configuation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.CheckBox enableAuditLogCheckbox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label MasterUserNameLabel;
        private System.Windows.Forms.Label MasterPasswordLabel;
        private System.Windows.Forms.TextBox MasterUserNameTextBox;
        private System.Windows.Forms.TextBox MasterPasswordTextBox;
        private System.Windows.Forms.Button CreateTableEnableLogginButton;
    }
}