namespace DCAnalyticsModellingDesktop
{
    partial class TransitionConditionBuilder
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
            this.cardinalityGroupBox = new System.Windows.Forms.GroupBox();
            this.radioPanel1 = new DCAnalyticsModellingDesktop.RadioPanel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._txtValidationValue = new System.Windows.Forms.TextBox();
            this._cmbQualifier = new System.Windows.Forms.ComboBox();
            this._cmbValidationType = new System.Windows.Forms.ComboBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._cmbForm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._cmbQuestions = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxAnswers = new System.Windows.Forms.ComboBox();
            this.cardinalityGroupBox.SuspendLayout();
            this.radioPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardinalityGroupBox
            // 
            this.cardinalityGroupBox.Controls.Add(this.radioPanel1);
            this.cardinalityGroupBox.Location = new System.Drawing.Point(16, 15);
            this.cardinalityGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.cardinalityGroupBox.Name = "cardinalityGroupBox";
            this.cardinalityGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.cardinalityGroupBox.Size = new System.Drawing.Size(504, 86);
            this.cardinalityGroupBox.TabIndex = 53;
            this.cardinalityGroupBox.TabStop = false;
            this.cardinalityGroupBox.Text = "Transition Type";
            // 
            // radioPanel1
            // 
            this.radioPanel1.Controls.Add(this.radioButton2);
            this.radioPanel1.Controls.Add(this.radioButton1);
            this.radioPanel1.Location = new System.Drawing.Point(8, 20);
            this.radioPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.radioPanel1.Name = "radioPanel1";
            this.radioPanel1.Size = new System.Drawing.Size(471, 54);
            this.radioPanel1.TabIndex = 40;
            this.radioPanel1.ValueMember = null;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(28, 20);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(96, 21);
            this.radioButton2.TabIndex = 40;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "0";
            this.radioButton2.Text = "Navigation";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(191, 20);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(170, 21);
            this.radioButton1.TabIndex = 41;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "1";
            this.radioButton1.Text = "Conditional Navigation";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "Qualifier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Type";
            // 
            // _txtValidationValue
            // 
            this._txtValidationValue.Location = new System.Drawing.Point(501, 38);
            this._txtValidationValue.Margin = new System.Windows.Forms.Padding(4);
            this._txtValidationValue.Name = "_txtValidationValue";
            this._txtValidationValue.Size = new System.Drawing.Size(153, 22);
            this._txtValidationValue.TabIndex = 58;
            // 
            // _cmbQualifier
            // 
            this._cmbQualifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbQualifier.FormattingEnabled = true;
            this._cmbQualifier.Location = new System.Drawing.Point(343, 37);
            this._cmbQualifier.Margin = new System.Windows.Forms.Padding(4);
            this._cmbQualifier.Name = "_cmbQualifier";
            this._cmbQualifier.Size = new System.Drawing.Size(144, 24);
            this._cmbQualifier.TabIndex = 57;
            // 
            // _cmbValidationType
            // 
            this._cmbValidationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbValidationType.FormattingEnabled = true;
            this._cmbValidationType.Location = new System.Drawing.Point(181, 36);
            this._cmbValidationType.Margin = new System.Windows.Forms.Padding(4);
            this._cmbValidationType.Name = "_cmbValidationType";
            this._cmbValidationType.Size = new System.Drawing.Size(139, 24);
            this._cmbValidationType.TabIndex = 56;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(598, 242);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(101, 32);
            this._btnCancel.TabIndex = 55;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(475, 242);
            this._btnOK.Margin = new System.Windows.Forms.Padding(4);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(101, 32);
            this._btnOK.TabIndex = 54;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 62;
            this.label4.Text = "Target Object";
            // 
            // _cmbForm
            // 
            this._cmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbForm.FormattingEnabled = true;
            this._cmbForm.Location = new System.Drawing.Point(16, 122);
            this._cmbForm.Margin = new System.Windows.Forms.Padding(4);
            this._cmbForm.Name = "_cmbForm";
            this._cmbForm.Size = new System.Drawing.Size(165, 24);
            this._cmbForm.TabIndex = 63;
            this._cmbForm.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this._cmbForm_DrawItem);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "Question";
            // 
            // _cmbQuestions
            // 
            this._cmbQuestions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbQuestions.FormattingEnabled = true;
            this._cmbQuestions.Location = new System.Drawing.Point(8, 34);
            this._cmbQuestions.Margin = new System.Windows.Forms.Padding(4);
            this._cmbQuestions.Name = "_cmbQuestions";
            this._cmbQuestions.Size = new System.Drawing.Size(157, 24);
            this._cmbQuestions.TabIndex = 64;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxAnswers);
            this.groupBox1.Controls.Add(this._cmbQuestions);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._cmbValidationType);
            this.groupBox1.Controls.Add(this._cmbQualifier);
            this.groupBox1.Controls.Add(this._txtValidationValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(16, 154);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(675, 79);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // comboBoxAnswers
            // 
            this.comboBoxAnswers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnswers.FormattingEnabled = true;
            this.comboBoxAnswers.Location = new System.Drawing.Point(501, 36);
            this.comboBoxAnswers.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAnswers.Name = "comboBoxAnswers";
            this.comboBoxAnswers.Size = new System.Drawing.Size(153, 24);
            this.comboBoxAnswers.TabIndex = 66;
            // 
            // TransitionConditionBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 277);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._cmbForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this.cardinalityGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransitionConditionBuilder";
            this.ShowInTaskbar = false;
            this.Text = "Transition Condition Builder";
            this.cardinalityGroupBox.ResumeLayout(false);
            this.radioPanel1.ResumeLayout(false);
            this.radioPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox cardinalityGroupBox;
        private RadioPanel radioPanel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtValidationValue;
        private System.Windows.Forms.ComboBox _cmbQualifier;
        private System.Windows.Forms.ComboBox _cmbValidationType;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _cmbForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cmbQuestions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxAnswers;
    }
}