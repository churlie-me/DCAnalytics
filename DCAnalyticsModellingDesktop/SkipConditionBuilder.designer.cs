namespace DCAnalyticsModellingDesktop
{
    partial class SkipConditionBuilder
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
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._cmbQualifier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAnswers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSkipTo = new System.Windows.Forms.ComboBox();
            this.comboBoxEnums = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(456, 111);
            this._btnOK.Margin = new System.Windows.Forms.Padding(4);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(101, 32);
            this._btnOK.TabIndex = 0;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(579, 111);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(101, 32);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _cmbQualifier
            // 
            this._cmbQualifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbQualifier.FormattingEnabled = true;
            this._cmbQualifier.Location = new System.Drawing.Point(348, 62);
            this._cmbQualifier.Margin = new System.Windows.Forms.Padding(4);
            this._cmbQualifier.Name = "_cmbQualifier";
            this._cmbQualifier.Size = new System.Drawing.Size(155, 24);
            this._cmbQualifier.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Qualifier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Answer";
            // 
            // comboBoxAnswers
            // 
            this.comboBoxAnswers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnswers.FormattingEnabled = true;
            this.comboBoxAnswers.Location = new System.Drawing.Point(185, 62);
            this.comboBoxAnswers.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAnswers.Name = "comboBoxAnswers";
            this.comboBoxAnswers.Size = new System.Drawing.Size(155, 24);
            this.comboBoxAnswers.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Skip to";
            // 
            // comboBoxSkipTo
            // 
            this.comboBoxSkipTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSkipTo.FormattingEnabled = true;
            this.comboBoxSkipTo.Location = new System.Drawing.Point(523, 62);
            this.comboBoxSkipTo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSkipTo.Name = "comboBoxSkipTo";
            this.comboBoxSkipTo.Size = new System.Drawing.Size(157, 24);
            this.comboBoxSkipTo.TabIndex = 9;
            // 
            // comboBoxEnums
            // 
            this.comboBoxEnums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnums.FormattingEnabled = true;
            this.comboBoxEnums.Location = new System.Drawing.Point(12, 62);
            this.comboBoxEnums.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxEnums.Name = "comboBoxEnums";
            this.comboBoxEnums.Size = new System.Drawing.Size(155, 24);
            this.comboBoxEnums.TabIndex = 12;
            this.comboBoxEnums.SelectedIndexChanged += new System.EventHandler(this.comboBoxEnums_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enums";
            // 
            // SkipConditionBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 156);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxEnums);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxSkipTo);
            this.Controls.Add(this.comboBoxAnswers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cmbQualifier);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SkipConditionBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skip Condition Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.ComboBox _cmbQualifier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxAnswers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSkipTo;
        private System.Windows.Forms.ComboBox comboBoxEnums;
        private System.Windows.Forms.Label label1;
    }
}