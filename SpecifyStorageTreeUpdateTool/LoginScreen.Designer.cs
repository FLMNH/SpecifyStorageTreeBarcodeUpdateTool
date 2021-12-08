namespace SpecifyStorageTreeUpdateTool
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.lblDatabaseServer = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(499, 37);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Specify Storage Tree Update Tool";
            // 
            // tbServerName
            // 
            this.tbServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServerName.Location = new System.Drawing.Point(213, 108);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(255, 26);
            this.tbServerName.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tbServerName, "Enter MySQL Server Address");
            // 
            // lblDatabaseServer
            // 
            this.lblDatabaseServer.AutoSize = true;
            this.lblDatabaseServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseServer.Location = new System.Drawing.Point(15, 111);
            this.lblDatabaseServer.Name = "lblDatabaseServer";
            this.lblDatabaseServer.Size = new System.Drawing.Size(192, 20);
            this.lblDatabaseServer.TabIndex = 6;
            this.lblDatabaseServer.Text = "Database Server Address";
            this.toolTip1.SetToolTip(this.lblDatabaseServer, "Enter MySQL Server Address");
            // 
            // tbDBName
            // 
            this.tbDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDBName.Location = new System.Drawing.Point(213, 140);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(255, 26);
            this.tbDBName.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbDBName, "Enter Specify database name.");
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseName.Location = new System.Drawing.Point(82, 143);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(125, 20);
            this.lblDatabaseName.TabIndex = 7;
            this.lblDatabaseName.Text = "Database Name";
            this.toolTip1.SetToolTip(this.lblDatabaseName, "Enter Specify database name.");
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(213, 172);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(255, 26);
            this.tbUserName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tbUserName, "Enter MySQL user name.");
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(62, 175);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(145, 20);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "Specify User Name";
            this.toolTip1.SetToolTip(this.lblUserName, "Enter MySQL user name.");
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(213, 204);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(255, 26);
            this.tbPassword.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbPassword, "MySQL User Password");
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(129, 207);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password";
            this.toolTip1.SetToolTip(this.lblPassword, "MySQL User Password");
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(334, 268);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(134, 28);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.toolTip1.SetToolTip(this.btnConnect, "Connect to Database");
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKey.Location = new System.Drawing.Point(213, 236);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(255, 26);
            this.tbKey.TabIndex = 10;
            this.toolTip1.SetToolTip(this.tbKey, "Specify User Key");
            this.tbKey.UseSystemPasswordChar = true;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(134, 239);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(73, 20);
            this.lblKey.TabIndex = 11;
            this.lblKey.Text = "User Key";
            this.toolTip1.SetToolTip(this.lblKey, "Specify User Key");
            // 
            // LoginScreen
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 350);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.tbDBName);
            this.Controls.Add(this.lblDatabaseServer);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblDatabaseServer;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lblKey;
    }
}