namespace DCAnalyticsModellingDesktop
{
    partial class SolutionExplorer
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
            this._tvSolutionExplorer = new System.Windows.Forms.TreeView();
            this._tsSolutionExplorer = new System.Windows.Forms.ToolStrip();
            this._btnRefresh = new System.Windows.Forms.ToolStripButton();
            this._tsSolutionExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tvSolutionExplorer
            // 
            this._tvSolutionExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tvSolutionExplorer.Location = new System.Drawing.Point(0, 27);
            this._tvSolutionExplorer.Margin = new System.Windows.Forms.Padding(4);
            this._tvSolutionExplorer.Name = "_tvSolutionExplorer";
            this._tvSolutionExplorer.Size = new System.Drawing.Size(433, 423);
            this._tvSolutionExplorer.TabIndex = 3;
            // 
            // _tsSolutionExplorer
            // 
            this._tsSolutionExplorer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._tsSolutionExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnRefresh});
            this._tsSolutionExplorer.Location = new System.Drawing.Point(0, 0);
            this._tsSolutionExplorer.Name = "_tsSolutionExplorer";
            this._tsSolutionExplorer.Size = new System.Drawing.Size(433, 27);
            this._tsSolutionExplorer.TabIndex = 2;
            this._tsSolutionExplorer.Text = "toolStrip1";
            // 
            // _btnRefresh
            // 
            this._btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnRefresh.Image = global::DCAnalyticsModellingDesktop.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this._btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.Size = new System.Drawing.Size(29, 24);
            this._btnRefresh.Text = "Refresh";
            // 
            // SolutionExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 450);
            this.Controls.Add(this._tvSolutionExplorer);
            this.Controls.Add(this._tsSolutionExplorer);
            this.Name = "SolutionExplorer";
            this.Text = "SolutionExplorer";
            this._tsSolutionExplorer.ResumeLayout(false);
            this._tsSolutionExplorer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView _tvSolutionExplorer;
        private System.Windows.Forms.ToolStrip _tsSolutionExplorer;
        private System.Windows.Forms.ToolStripButton _btnRefresh;
    }
}