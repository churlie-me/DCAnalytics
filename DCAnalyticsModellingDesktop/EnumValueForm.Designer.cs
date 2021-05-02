namespace DCAnalyticsModellingDesktop
{
    partial class EnumValueForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEnumValue = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.TextBoxEnumValueName = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(328, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(328, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "*";
            // 
            // textBoxEnumValue
            // 
            this.textBoxEnumValue.Location = new System.Drawing.Point(120, 53);
            this.textBoxEnumValue.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEnumValue.Name = "textBoxEnumValue";
            this.textBoxEnumValue.Size = new System.Drawing.Size(203, 22);
            this.textBoxEnumValue.TabIndex = 0;
            this.textBoxEnumValue.Tag = "None";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(12, 53);
            this.labelCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(41, 17);
            this.labelCode.TabIndex = 17;
            this.labelCode.Text = "Code";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(9, 95);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(83, 17);
            this.labelDescription.TabIndex = 16;
            this.labelDescription.Text = "Description:";
            // 
            // TextBoxEnumValueName
            // 
            this.TextBoxEnumValueName.Location = new System.Drawing.Point(120, 95);
            this.TextBoxEnumValueName.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxEnumValueName.Name = "TextBoxEnumValueName";
            this.TextBoxEnumValueName.Size = new System.Drawing.Size(203, 22);
            this.TextBoxEnumValueName.TabIndex = 1;
            this.TextBoxEnumValueName.Tag = "None";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(367, 27);
            this.toolStrip2.TabIndex = 20;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.if_save_173091;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonSave.Text = "Save and close";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCancel.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.icons8_delete_4811;
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonCancel.Text = "Cancel";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // EnumValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 140);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEnumValue);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.TextBoxEnumValueName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EnumValueForm";
            this.Text = "Enum Value ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnumValueForm_FormClosing);
            this.Load += new System.EventHandler(this.EnumValueForm_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEnumValue;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox TextBoxEnumValueName;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
    }
}