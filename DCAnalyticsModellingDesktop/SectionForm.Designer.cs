namespace DCAnalyticsModellingDesktop
{
    partial class SectionForm
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
            this.tabPageQuestions = new System.Windows.Forms.TabPage();
            this.dataGridViewQuestions = new System.Windows.Forms.DataGridView();
            this.toolStripAddQuestion = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.closedQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleChoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewTransitionLinks = new System.Windows.Forms.DataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddTransition = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewSkipConditions = new System.Windows.Forms.DataGridView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mapQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPageSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabPageQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).BeginInit();
            this.toolStripAddQuestion.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransitionLinks)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkipConditions)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSections);
            this.tabControl1.Controls.Add(this.tabPageQuestions);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 108);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1033, 457);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageSections
            // 
            this.tabPageSections.Controls.Add(this.dataGridViewSections);
            this.tabPageSections.Controls.Add(this.toolStrip1);
            this.tabPageSections.Location = new System.Drawing.Point(4, 25);
            this.tabPageSections.Name = "tabPageSections";
            this.tabPageSections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSections.Size = new System.Drawing.Size(1025, 428);
            this.tabPageSections.TabIndex = 0;
            this.tabPageSections.Text = "Sub Sections";
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
            this.dataGridViewSections.Size = new System.Drawing.Size(1019, 395);
            this.dataGridViewSections.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddSection});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1019, 27);
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
            this.toolStripButtonAddSection.Text = "toolStripButton1";
            this.toolStripButtonAddSection.Click += new System.EventHandler(this.toolStripButtonAddSection_Click);
            // 
            // tabPageQuestions
            // 
            this.tabPageQuestions.Controls.Add(this.dataGridViewQuestions);
            this.tabPageQuestions.Controls.Add(this.toolStripAddQuestion);
            this.tabPageQuestions.Location = new System.Drawing.Point(4, 25);
            this.tabPageQuestions.Name = "tabPageQuestions";
            this.tabPageQuestions.Size = new System.Drawing.Size(1025, 428);
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
            this.dataGridViewQuestions.Size = new System.Drawing.Size(1025, 401);
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
            this.multipleChoiceToolStripMenuItem,
            this.mapQuestionToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.icons8_plus_48;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // closedQuestionToolStripMenuItem
            // 
            this.closedQuestionToolStripMenuItem.Name = "closedQuestionToolStripMenuItem";
            this.closedQuestionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closedQuestionToolStripMenuItem.Text = "Closed";
            this.closedQuestionToolStripMenuItem.Click += new System.EventHandler(this.closedQuestionToolStripMenuItem_Click);
            // 
            // openQuestionToolStripMenuItem
            // 
            this.openQuestionToolStripMenuItem.Name = "openQuestionToolStripMenuItem";
            this.openQuestionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openQuestionToolStripMenuItem.Text = "Open";
            this.openQuestionToolStripMenuItem.Click += new System.EventHandler(this.openQuestionToolStripMenuItem_Click);
            // 
            // multipleChoiceToolStripMenuItem
            // 
            this.multipleChoiceToolStripMenuItem.Name = "multipleChoiceToolStripMenuItem";
            this.multipleChoiceToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.multipleChoiceToolStripMenuItem.Text = "Multiple Choice";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewTransitionLinks);
            this.tabPage1.Controls.Add(this.toolStrip3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1025, 428);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Transition links";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTransitionLinks
            // 
            this.dataGridViewTransitionLinks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewTransitionLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransitionLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransitionLinks.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewTransitionLinks.Name = "dataGridViewTransitionLinks";
            this.dataGridViewTransitionLinks.RowHeadersWidth = 51;
            this.dataGridViewTransitionLinks.RowTemplate.Height = 24;
            this.dataGridViewTransitionLinks.Size = new System.Drawing.Size(1025, 401);
            this.dataGridViewTransitionLinks.TabIndex = 4;
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddTransition});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1025, 27);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButtonAddTransition
            // 
            this.toolStripButtonAddTransition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddTransition.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.icons8_plus_48;
            this.toolStripButtonAddTransition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddTransition.Name = "toolStripButtonAddTransition";
            this.toolStripButtonAddTransition.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonAddTransition.Text = "toolStripButton1";
            this.toolStripButtonAddTransition.Click += new System.EventHandler(this.toolStripButtonAddTransition_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewSkipConditions);
            this.tabPage2.Controls.Add(this.toolStrip4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1025, 428);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Skip Conditions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSkipConditions
            // 
            this.dataGridViewSkipConditions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewSkipConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSkipConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSkipConditions.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewSkipConditions.Name = "dataGridViewSkipConditions";
            this.dataGridViewSkipConditions.RowHeadersWidth = 51;
            this.dataGridViewSkipConditions.RowTemplate.Height = 24;
            this.dataGridViewSkipConditions.Size = new System.Drawing.Size(1025, 401);
            this.dataGridViewSkipConditions.TabIndex = 4;
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(1025, 27);
            this.toolStrip4.TabIndex = 1;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.icons8_plus_48;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton1";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1057, 27);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::DCAnalyticsModellingDesktop.Properties.Resources.if_save_173091;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSave.Text = "toolStripButton1";
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
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(110, 57);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(638, 22);
            this.textBoxName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // mapQuestionToolStripMenuItem
            // 
            this.mapQuestionToolStripMenuItem.Name = "mapQuestionToolStripMenuItem";
            this.mapQuestionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mapQuestionToolStripMenuItem.Text = "Map Question";
            this.mapQuestionToolStripMenuItem.Click += new System.EventHandler(this.mapQuestionToolStripMenuItem_Click);
            // 
            // SectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 577);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "SectionForm";
            this.Text = "Section";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SectionForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSections.ResumeLayout(false);
            this.tabPageSections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPageQuestions.ResumeLayout(false);
            this.tabPageQuestions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).EndInit();
            this.toolStripAddQuestion.ResumeLayout(false);
            this.toolStripAddQuestion.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransitionLinks)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkipConditions)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSections;
        private System.Windows.Forms.DataGridView dataGridViewSections;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddSection;
        private System.Windows.Forms.TabPage tabPageQuestions;
        private System.Windows.Forms.DataGridView dataGridViewQuestions;
        private System.Windows.Forms.ToolStrip toolStripAddQuestion;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem closedQuestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openQuestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleChoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewTransitionLinks;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddTransition;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewSkipConditions;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem mapQuestionToolStripMenuItem;
    }
}