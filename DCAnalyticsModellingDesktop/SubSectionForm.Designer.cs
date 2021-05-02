namespace DCAnalyticsModellingDesktop
{
    partial class SubSectionForm
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
            this.tabPageQuestions = new System.Windows.Forms.TabPage();
            this.dataGridViewQuestions = new System.Windows.Forms.DataGridView();
            this.toolStripAddQuestion = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.closedQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleChoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPageQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).BeginInit();
            this.toolStripAddQuestion.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageQuestions);
            this.tabControl1.Location = new System.Drawing.Point(12, 91);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1033, 428);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageQuestions
            // 
            this.tabPageQuestions.Controls.Add(this.dataGridViewQuestions);
            this.tabPageQuestions.Controls.Add(this.toolStripAddQuestion);
            this.tabPageQuestions.Location = new System.Drawing.Point(4, 25);
            this.tabPageQuestions.Name = "tabPageQuestions";
            this.tabPageQuestions.Size = new System.Drawing.Size(1025, 399);
            this.tabPageQuestions.TabIndex = 1;
            this.tabPageQuestions.Text = "Questions";
            this.tabPageQuestions.UseVisualStyleBackColor = true;
            // 
            // dataGridViewQuestions
            // 
            this.dataGridViewQuestions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQuestions.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewQuestions.Name = "dataGridViewQuestions";
            this.dataGridViewQuestions.RowHeadersWidth = 51;
            this.dataGridViewQuestions.RowTemplate.Height = 24;
            this.dataGridViewQuestions.Size = new System.Drawing.Size(1025, 372);
            this.dataGridViewQuestions.TabIndex = 3;
            // 
            // toolStripAddQuestion
            // 
            this.toolStripAddQuestion.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripAddQuestion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStripAddQuestion.Location = new System.Drawing.Point(0, 0);
            this.toolStripAddQuestion.Name = "toolStripAddQuestion";
            this.toolStripAddQuestion.Size = new System.Drawing.Size(1025, 27);
            this.toolStripAddQuestion.TabIndex = 2;
            this.toolStripAddQuestion.Text = "toolStrip3";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closedQuestionToolStripMenuItem,
            this.openQuestionToolStripMenuItem,
            this.multipleChoiceToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.icons8_plus_48;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // closedQuestionToolStripMenuItem
            // 
            this.closedQuestionToolStripMenuItem.Name = "closedQuestionToolStripMenuItem";
            this.closedQuestionToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.closedQuestionToolStripMenuItem.Text = "Closed";
            this.closedQuestionToolStripMenuItem.Click += new System.EventHandler(this.closedQuestionToolStripMenuItem_Click);
            // 
            // openQuestionToolStripMenuItem
            // 
            this.openQuestionToolStripMenuItem.Name = "openQuestionToolStripMenuItem";
            this.openQuestionToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.openQuestionToolStripMenuItem.Text = "Open";
            this.openQuestionToolStripMenuItem.Click += new System.EventHandler(this.openQuestionToolStripMenuItem_Click);
            // 
            // multipleChoiceToolStripMenuItem
            // 
            this.multipleChoiceToolStripMenuItem.Name = "multipleChoiceToolStripMenuItem";
            this.multipleChoiceToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.multipleChoiceToolStripMenuItem.Text = "Multiple Choice";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1073, 31);
            this.toolStrip2.TabIndex = 11;
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
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(110, 40);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(638, 22);
            this.textBoxName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
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
            // SubSectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 531);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "SubSectionForm";
            this.Text = "Sub Section";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubSectionForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageQuestions.ResumeLayout(false);
            this.tabPageQuestions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).EndInit();
            this.toolStripAddQuestion.ResumeLayout(false);
            this.toolStripAddQuestion.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageQuestions;
        private System.Windows.Forms.DataGridView dataGridViewQuestions;
        private System.Windows.Forms.ToolStrip toolStripAddQuestion;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem closedQuestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openQuestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleChoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
    }
}