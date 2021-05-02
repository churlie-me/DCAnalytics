
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DCAnalyticsModellingDesktop
{
    partial class UserManagementForm
    {
        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridViewUsers;
        private ToolStrip toolStrip3;
        private ToolStripButton toolStripButtonAddCategory;
        private ToolStripButton toolStripButtonEditCategory;
        private ToolStripButton toolStripButtonDeleteCategory;
        private TabControl tabControl2;
        private TabPage tabPage2;
        private Button buttonUpdate;
        private ListView listViewPermissions;
        private Panel panel1;
        private ListView listViewUserRights;
        private DataGridView dataGridViewUserRights;
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
            this.splitContainer1 = new SplitContainer();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.dataGridViewUsers = new DataGridView();
            this.toolStrip3 = new ToolStrip();
            this.toolStripButtonAddCategory = new ToolStripButton();
            this.toolStripButtonEditCategory = new ToolStripButton();
            this.toolStripButtonDeleteCategory = new ToolStripButton();
            this.tabControl2 = new TabControl();
            this.tabPage2 = new TabPage();
            this.panel1 = new Panel();
            this.dataGridViewUserRights = new DataGridView();
            this.listViewUserRights = new ListView();
            this.listViewPermissions = new ListView();
            this.buttonUpdate = new Button();
            this.splitContainer1.BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((ISupportInitialize)this.dataGridViewUsers).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize)this.dataGridViewUserRights).BeginInit();
            this.SuspendLayout();
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add((Control)this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add((Control)this.tabControl2);
            this.splitContainer1.Size = new Size(889, 594);
            this.splitContainer1.SplitterDistance = 477;
            this.splitContainer1.TabIndex = 0;
            this.tabControl1.Controls.Add((Control)this.tabPage1);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(477, 594);
            this.tabControl1.TabIndex = 1;
            this.tabPage1.Controls.Add((Control)this.dataGridViewUsers);
            this.tabPage1.Controls.Add((Control)this.toolStrip3);
            this.tabPage1.Location = new Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(469, 565);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.BackgroundColor = SystemColors.ButtonHighlight;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new Point(73, 5);
            this.dataGridViewUsers.Margin = new Padding(5);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowTemplate.Height = 24;
            this.dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new Size(393, 557);
            this.dataGridViewUsers.TabIndex = 3;
            this.dataGridViewUsers.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dataGridViewUsers_CellBeginEdit);
            this.dataGridViewUsers.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewUsers_CellContentClick);
            this.dataGridViewUsers.SelectionChanged += new EventHandler(this.dataGridViewUsers_SelectionChanged);
            this.toolStrip3.Dock = DockStyle.Left;
            this.toolStrip3.ImageScalingSize = new Size(60, 60);
            this.toolStrip3.Items.AddRange(new ToolStripItem[3]
            {
        (ToolStripItem) this.toolStripButtonAddCategory,
        (ToolStripItem) this.toolStripButtonEditCategory,
        (ToolStripItem) this.toolStripButtonDeleteCategory
            });
            this.toolStrip3.Location = new Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new Size(65, 559);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            this.toolStripButtonAddCategory.DisplayStyle = ToolStripItemDisplayStyle.Image;
           // this.toolStripButtonAddCategory.Image = (Image)HarvestSuperMarketPOS.Properties.Resources.icons8_plus_48;
            this.toolStripButtonAddCategory.ImageTransparentColor = Color.Magenta;
            this.toolStripButtonAddCategory.Name = "toolStripButtonAddCategory";
            this.toolStripButtonAddCategory.Size = new Size(62, 64);
            this.toolStripButtonAddCategory.Text = "Add User";
            this.toolStripButtonAddCategory.Click += new EventHandler(this.toolStripButtonAddCategory_Click);
            this.toolStripButtonEditCategory.DisplayStyle = ToolStripItemDisplayStyle.Image;
           // this.toolStripButtonEditCategory.Image = (Image)HarvestSuperMarketPOS.Properties.Resources.if_document_edit_23209;
            this.toolStripButtonEditCategory.ImageTransparentColor = Color.Magenta;
            this.toolStripButtonEditCategory.Name = "toolStripButtonEditCategory";
            this.toolStripButtonEditCategory.Size = new Size(62, 64);
            this.toolStripButtonEditCategory.Text = "Edit User";
            this.toolStripButtonEditCategory.Click += new EventHandler(this.toolStripButtonEditCategory_Click);
            this.toolStripButtonDeleteCategory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            //this.toolStripButtonDeleteCategory.Image = (Image)HarvestSuperMarketPOS.Properties.Resources.icons8_delete_481;
            this.toolStripButtonDeleteCategory.ImageTransparentColor = Color.Magenta;
            this.toolStripButtonDeleteCategory.Name = "toolStripButtonDeleteCategory";
            this.toolStripButtonDeleteCategory.Size = new Size(62, 64);
            this.toolStripButtonDeleteCategory.Text = "Delete User";
            this.toolStripButtonDeleteCategory.Click += new EventHandler(this.toolStripButtonDeleteCategory_Click);
            this.tabControl2.Controls.Add((Control)this.tabPage2);
            this.tabControl2.Dock = DockStyle.Fill;
            this.tabControl2.Location = new Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new Size(408, 594);
            this.tabControl2.TabIndex = 2;
            this.tabPage2.Controls.Add((Control)this.panel1);
            this.tabPage2.Controls.Add((Control)this.listViewPermissions);
            this.tabPage2.Controls.Add((Control)this.buttonUpdate);
            this.tabPage2.Location = new Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(400, 565);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "User Rights";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.panel1.Controls.Add((Control)this.dataGridViewUserRights);
            this.panel1.Controls.Add((Control)this.listViewUserRights);
            this.panel1.Location = new Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(386, 394);
            this.panel1.TabIndex = 7;
            this.dataGridViewUserRights.BackgroundColor = SystemColors.ButtonHighlight;
            this.dataGridViewUserRights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserRights.Dock = DockStyle.Fill;
            this.dataGridViewUserRights.Location = new Point(0, 0);
            this.dataGridViewUserRights.Name = "dataGridViewUserRights";
            this.dataGridViewUserRights.RowTemplate.Height = 24;
            this.dataGridViewUserRights.Size = new Size(386, 394);
            this.dataGridViewUserRights.TabIndex = 6;
            this.dataGridViewUserRights.SelectionChanged += new EventHandler(this.dataGridView1_SelectionChanged);
            this.listViewUserRights.Dock = DockStyle.Fill;
            this.listViewUserRights.Location = new Point(0, 0);
            this.listViewUserRights.MultiSelect = false;
            this.listViewUserRights.Name = "listViewUserRights";
            this.listViewUserRights.Size = new Size(386, 394);
            this.listViewUserRights.TabIndex = 5;
            this.listViewUserRights.UseCompatibleStateImageBehavior = false;
            this.listViewUserRights.ItemChecked += new ItemCheckedEventHandler(this.listViewUserRights_ItemChecked);
            this.listViewPermissions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.listViewPermissions.Location = new Point(6, 406);
            this.listViewPermissions.Name = "listViewPermissions";
            this.listViewPermissions.Size = new Size(253, 148);
            this.listViewPermissions.TabIndex = 6;
            this.listViewPermissions.UseCompatibleStateImageBehavior = false;
            this.listViewPermissions.ItemChecked += new ItemCheckedEventHandler(this.listViewPermissions_ItemChecked);
            this.buttonUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonUpdate.Location = new Point(265, 406);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new Size(130, 148);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new EventHandler(this.buttonUpdate_Click);
            this.AutoScaleDimensions = new SizeF(8f, 16f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(889, 594);
            this.Controls.Add((Control)this.splitContainer1);
            this.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.Name = "User Management";
            this.Text = "User Management";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(this.UserManagementForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((ISupportInitialize)this.dataGridViewUsers).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize)this.dataGridViewUserRights).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}