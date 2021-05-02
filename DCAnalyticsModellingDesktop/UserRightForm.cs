
using DCAnalytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCAnalyticsModellingDesktop
{
    public partial class UserRightForm : Form
    {
        private bool _applied;
        private bool _isCancelling;
        private UserRight _userRight;

        public UserRightForm(UserRight userRight)
        {
            this.InitializeComponent();
            this._userRight = userRight;
         //   this.textBoxName.Text = this._userRight.Name;
            this.CenterToParent();
        }

        private void AssignValues()
        {
            //this._userRight.CreatedBy = MediApp.Instance.CurrentUser.FirstName;
            //this._userRight.LastUpdatedBy = "Admin";
            //this._userRight.Name = this.textBoxName.Text;
        }

        private void Save(out bool fine, bool apply = false)
        {
            fine = false;
            try
            {
                if (!this._applied)
                {
                    this.AssignValues();
                    this._userRight.Update();
                }
                if (!apply)
                {
                    this._isCancelling = true;
                    this.DialogResult = DialogResult.OK;
                }
                fine = true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                fine = false;
            }
        }

        private void Apply()
        {
            bool fine;
            this.Save(out fine, true);
            if (!fine)
                return;
            this._applied = true;
        }

        private void OnClosingForm()
        {
            if (this._isCancelling)
                return;
            this.AssignValues();
            if (this._userRight.ObjectState == ObjectStates.None)
                return;
            if (MessageBox.Show("Are you sure you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this._userRight.Update();
            else
                this._userRight.Cancel();
        }

        private void toolStripButtonApply_Click(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            bool fine;
            this.Save(out fine, false);
        }

        private void CancelOperation()
        {
            this._userRight.Cancel();
            this._isCancelling = true;
            this.DialogResult = DialogResult.Cancel;
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            this.CancelOperation();
        }

        private void UserRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.OnClosingForm();
        }
    }
}
