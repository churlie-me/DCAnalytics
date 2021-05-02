namespace DCAnalyticsModellingDesktop
{
    partial class QuestionaireForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSections = new System.Windows.Forms.TabPage();
            this.dataGridViewSections = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddSection = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPageSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSections);
            this.tabControl1.Location = new System.Drawing.Point(12, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1110, 371);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSections
            // 
            this.tabPageSections.Controls.Add(this.dataGridViewSections);
            this.tabPageSections.Controls.Add(this.toolStrip1);
            this.tabPageSections.Location = new System.Drawing.Point(4, 25);
            this.tabPageSections.Name = "tabPageSections";
            this.tabPageSections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSections.Size = new System.Drawing.Size(1102, 342);
            this.tabPageSections.TabIndex = 0;
            this.tabPageSections.Text = "Sections";
            this.tabPageSections.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSections
            // 
            this.dataGridViewSections.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSections.Location = new System.Drawing.Point(3, 30);
            this.dataGridViewSections.Name = "dataGridViewSections";
            this.dataGridViewSections.RowHeadersWidth = 51;
            this.dataGridViewSections.RowTemplate.Height = 24;
            this.dataGridViewSections.Size = new System.Drawing.Size(1096, 309);
            this.dataGridViewSections.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddSection});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1096, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddSection
            // 
            this.toolStripButtonAddSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddSection.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.icons8_plus_48;
            this.toolStripButtonAddSection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddSection.Name = "toolStripButtonAddSection";
            this.toolStripButtonAddSection.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonAddSection.Text = "Add Section";
            this.toolStripButtonAddSection.Click += new System.EventHandler(this.toolStripButtonAddSection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(87, 55);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(659, 22);
            this.textBoxName.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1155, 31);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.if_save_173091;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonSave.Text = "toolStripButton1";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCancel.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.icons8_delete_4811;
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonCancel.Text = "Cancel";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // QuestionaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 522);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "QuestionaireForm";
            this.Text = "Questionaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionaireForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSections.ResumeLayout(false);
            this.tabPageSections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSections;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DataGridView dataGridViewSections;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
    }
}