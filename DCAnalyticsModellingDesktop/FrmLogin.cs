using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCAnalytics;

namespace DCAnalyticsModellingDesktop
{
    public partial class FrmLogin : Form
    {
        private bool _isLoggedIn;
        public FrmLogin()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private async Task<bool> LogIn()
        {
            DCAnalyticsApp.Instance.CurrentUser.UserName = _txtUserID.Text;
            DCAnalyticsApp.Instance.CurrentUser.Password = _txtPassword.Text;

            return await DCAnalyticsApp.Instance.CurrentUser.LogIn();
        }

        private void _btnLogin_Click(object sender, EventArgs e)
        {
           //Task<bool> b =  Task.Run<bool>(()=> { return LogIn(); });

            // () => { LogIn(); }
            //if (!_isLoggedIn)
            //    MessageBox.Show("Login failed");
            DialogResult = DialogResult.OK; /*b.Result ? DialogResult.OK : DialogResult.Cancel*/;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
