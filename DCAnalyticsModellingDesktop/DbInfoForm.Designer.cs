namespace DCAnalyticsModellingDesktop
{
    partial class DbInfoForm
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
            this.textBoxWebUrl = new System.Windows.Forms.TextBox();
            this._txtBoxPassword = new System.Windows.Forms.TextBox();
            this._txtBoxUserName = new System.Windows.Forms.TextBox();
            this._lblPassword = new System.Windows.Forms.Label();
            this._lblUserName = new System.Windows.Forms.Label();
            this._rdBtnDatabase = new System.Windows.Forms.RadioButton();
            this._rdBtnWindows = new System.Windows.Forms.RadioButton();
            this._lblSelectDb = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnTestConnection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._cmbBoxDatabase = new System.Windows.Forms.ComboBox();
            this._picLoading = new System.Windows.Forms.PictureBox();
            this._gpbServiceUrl = new System.Windows.Forms.GroupBox();
            this._cmbBoxServer = new System.Windows.Forms.ComboBox();
            this._gpbDbInfo = new System.Windows.Forms.GroupBox();
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._picLoading)).BeginInit();
            this._gpbServiceUrl.SuspendLayout();
            this._gpbDbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxWebUrl
            // 
            this.textBoxWebUrl.Location = new System.Drawing.Point(40, 23);
            this.textBoxWebUrl.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWebUrl.Name = "textBoxWebUrl";
            this.textBoxWebUrl.Size = new System.Drawing.Size(367, 22);
            this.textBoxWebUrl.TabIndex = 0;
            // 
            // _txtBoxPassword
            // 
            this._txtBoxPassword.Location = new System.Drawing.Point(149, 255);
            this._txtBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this._txtBoxPassword.Name = "_txtBoxPassword";
            this._txtBoxPassword.PasswordChar = '*';
            this._txtBoxPassword.Size = new System.Drawing.Size(208, 22);
            this._txtBoxPassword.TabIndex = 5;
            // 
            // _txtBoxUserName
            // 
            this._txtBoxUserName.Location = new System.Drawing.Point(149, 215);
            this._txtBoxUserName.Margin = new System.Windows.Forms.Padding(4);
            this._txtBoxUserName.Name = "_txtBoxUserName";
            this._txtBoxUserName.Size = new System.Drawing.Size(208, 22);
            this._txtBoxUserName.TabIndex = 4;
            // 
            // _lblPassword
            // 
            this._lblPassword.AutoSize = true;
            this._lblPassword.Location = new System.Drawing.Point(48, 256);
            this._lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblPassword.Name = "_lblPassword";
            this._lblPassword.Size = new System.Drawing.Size(73, 17);
            this._lblPassword.TabIndex = 8;
            this._lblPassword.Text = "Password:";
            // 
            // _lblUserName
            // 
            this._lblUserName.AutoSize = true;
            this._lblUserName.Location = new System.Drawing.Point(48, 218);
            this._lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblUserName.Name = "_lblUserName";
            this._lblUserName.Size = new System.Drawing.Size(83, 17);
            this._lblUserName.TabIndex = 7;
            this._lblUserName.Text = "User Name:";
            // 
            // _rdBtnDatabase
            // 
            this._rdBtnDatabase.AutoSize = true;
            this._rdBtnDatabase.Location = new System.Drawing.Point(52, 164);
            this._rdBtnDatabase.Margin = new System.Windows.Forms.Padding(4);
            this._rdBtnDatabase.Name = "_rdBtnDatabase";
            this._rdBtnDatabase.Size = new System.Drawing.Size(279, 21);
            this._rdBtnDatabase.TabIndex = 3;
            this._rdBtnDatabase.TabStop = true;
            this._rdBtnDatabase.Text = "Use a specific Username and Password";
            this._rdBtnDatabase.UseVisualStyleBackColor = true;
            this._rdBtnDatabase.CheckedChanged += new System.EventHandler(this._rdBtnDatabase_CheckedChanged_1);
            // 
            // _rdBtnWindows
            // 
            this._rdBtnWindows.AutoSize = true;
            this._rdBtnWindows.Location = new System.Drawing.Point(52, 134);
            this._rdBtnWindows.Margin = new System.Windows.Forms.Padding(4);
            this._rdBtnWindows.Name = "_rdBtnWindows";
            this._rdBtnWindows.Size = new System.Drawing.Size(260, 21);
            this._rdBtnWindows.TabIndex = 2;
            this._rdBtnWindows.TabStop = true;
            this._rdBtnWindows.Text = "Use Windows NT Integrated Security";
            this._rdBtnWindows.UseVisualStyleBackColor = true;
            this._rdBtnWindows.CheckedChanged += new System.EventHandler(this._rdBtnWindows_CheckedChanged_1);
            // 
            // _lblSelectDb
            // 
            this._lblSelectDb.AutoSize = true;
            this._lblSelectDb.Location = new System.Drawing.Point(7, 304);
            this._lblSelectDb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblSelectDb.Name = "_lblSelectDb";
            this._lblSelectDb.Size = new System.Drawing.Size(285, 17);
            this._lblSelectDb.TabIndex = 4;
            this._lblSelectDb.Text = "3. Select or Enter a Database on the Server";
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(206, 537);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(117, 34);
            this._btnCancel.TabIndex = 13;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click_1);
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Location = new System.Drawing.Point(86, 537);
            this._btnOk.Margin = new System.Windows.Forms.Padding(4);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(117, 34);
            this._btnOk.TabIndex = 12;
            this._btnOk.Text = "&OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click_1);
            // 
            // _btnTestConnection
            // 
            this._btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnTestConnection.Location = new System.Drawing.Point(160, 662);
            this._btnTestConnection.Margin = new System.Windows.Forms.Padding(4);
            this._btnTestConnection.Name = "_btnTestConnection";
            this._btnTestConnection.Size = new System.Drawing.Size(132, 34);
            this._btnTestConnection.TabIndex = 11;
            this._btnTestConnection.Text = "Test Connection";
            this._btnTestConnection.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Enter Information to Logon to the Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "1. Select or Enter a Server Name";
            // 
            // _cmbBoxDatabase
            // 
            this._cmbBoxDatabase.Enabled = false;
            this._cmbBoxDatabase.FormattingEnabled = true;
            this._cmbBoxDatabase.Location = new System.Drawing.Point(52, 330);
            this._cmbBoxDatabase.Margin = new System.Windows.Forms.Padding(4);
            this._cmbBoxDatabase.Name = "_cmbBoxDatabase";
            this._cmbBoxDatabase.Size = new System.Drawing.Size(305, 24);
            this._cmbBoxDatabase.TabIndex = 6;
            // 
            // _picLoading
            // 
            this._picLoading.Location = new System.Drawing.Point(300, 17);
            this._picLoading.Margin = new System.Windows.Forms.Padding(4);
            this._picLoading.Name = "_picLoading";
            this._picLoading.Size = new System.Drawing.Size(105, 78);
            this._picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picLoading.TabIndex = 11;
            this._picLoading.TabStop = false;
            this._picLoading.Visible = false;
            // 
            // _gpbServiceUrl
            // 
            this._gpbServiceUrl.Controls.Add(this.textBoxWebUrl);
            this._gpbServiceUrl.Location = new System.Drawing.Point(22, 13);
            this._gpbServiceUrl.Margin = new System.Windows.Forms.Padding(4);
            this._gpbServiceUrl.Name = "_gpbServiceUrl";
            this._gpbServiceUrl.Padding = new System.Windows.Forms.Padding(4);
            this._gpbServiceUrl.Size = new System.Drawing.Size(413, 62);
            this._gpbServiceUrl.TabIndex = 14;
            this._gpbServiceUrl.TabStop = false;
            this._gpbServiceUrl.Text = "Enter Web Service Url";
            // 
            // _cmbBoxServer
            // 
            this._cmbBoxServer.FormattingEnabled = true;
            this._cmbBoxServer.Location = new System.Drawing.Point(49, 44);
            this._cmbBoxServer.Margin = new System.Windows.Forms.Padding(4);
            this._cmbBoxServer.Name = "_cmbBoxServer";
            this._cmbBoxServer.Size = new System.Drawing.Size(287, 24);
            this._cmbBoxServer.TabIndex = 1;
            // 
            // _gpbDbInfo
            // 
            this._gpbDbInfo.Controls.Add(this._txtBoxPassword);
            this._gpbDbInfo.Controls.Add(this._txtBoxUserName);
            this._gpbDbInfo.Controls.Add(this._lblPassword);
            this._gpbDbInfo.Controls.Add(this._lblUserName);
            this._gpbDbInfo.Controls.Add(this._rdBtnDatabase);
            this._gpbDbInfo.Controls.Add(this._rdBtnWindows);
            this._gpbDbInfo.Controls.Add(this._lblSelectDb);
            this._gpbDbInfo.Controls.Add(this.label2);
            this._gpbDbInfo.Controls.Add(this.label1);
            this._gpbDbInfo.Controls.Add(this._cmbBoxDatabase);
            this._gpbDbInfo.Controls.Add(this._cmbBoxServer);
            this._gpbDbInfo.Controls.Add(this._picLoading);
            this._gpbDbInfo.Location = new System.Drawing.Point(22, 132);
            this._gpbDbInfo.Margin = new System.Windows.Forms.Padding(4);
            this._gpbDbInfo.Name = "_gpbDbInfo";
            this._gpbDbInfo.Padding = new System.Windows.Forms.Padding(4);
            this._gpbDbInfo.Size = new System.Drawing.Size(413, 371);
            this._gpbDbInfo.TabIndex = 10;
            this._gpbDbInfo.TabStop = false;
            this._gpbDbInfo.Text = "Provide Connection Information";
            // 
            // comboBoxProvider
            // 
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Location = new System.Drawing.Point(190, 91);
            this.comboBoxProvider.Name = "comboBoxProvider";
            this.comboBoxProvider.Size = new System.Drawing.Size(239, 24);
            this.comboBoxProvider.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Choose Provider";
            // 
            // DbInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 595);
            this.Controls.Add(this.comboBoxProvider);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._btnTestConnection);
            this.Controls.Add(this._gpbServiceUrl);
            this.Controls.Add(this._gpbDbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DbInfoForm";
            this.Text = "Database Info";
            ((System.ComponentModel.ISupportInitialize)(this._picLoading)).EndInit();
            this._gpbServiceUrl.ResumeLayout(false);
            this._gpbServiceUrl.PerformLayout();
            this._gpbDbInfo.ResumeLayout(false);
            this._gpbDbInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWebUrl;
        private System.Windows.Forms.TextBox _txtBoxPassword;
        private System.Windows.Forms.TextBox _txtBoxUserName;
        private System.Windows.Forms.Label _lblPassword;
        private System.Windows.Forms.Label _lblUserName;
        private System.Windows.Forms.RadioButton _rdBtnDatabase;
        private System.Windows.Forms.RadioButton _rdBtnWindows;
        private System.Windows.Forms.Label _lblSelectDb;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnTestConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cmbBoxDatabase;
        private System.Windows.Forms.PictureBox _picLoading;
        private System.Windows.Forms.GroupBox _gpbServiceUrl;
        private System.Windows.Forms.ComboBox _cmbBoxServer;
        private System.Windows.Forms.GroupBox _gpbDbInfo;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.Label label3;
    }
}