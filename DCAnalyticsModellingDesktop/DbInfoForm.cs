using DCAnalytics.Data;
using DCAnalytics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCAnalyticsModellingDesktop
{
    public partial class DbInfoForm : Form
    {
        private bool _isPublish = false;
        private string url = null;
        private bool _isCorrectUrl = false;

        public bool IsPublish
        {
            get { return _isPublish; }
            set { _isPublish = value; }
        }

        private bool _isImport = false;
        private Configuration _configuration;

        public bool IsIgcx = false;
        protected DbManager _dbInfo;

        private Settings _settings;
        //private ServerDataConnection _dataConnection;

        public bool ConfigurationCancelled { get; set; }

        public DbInfoForm()
        {
            InitializeComponent();
            CenterToScreen();
        }
        public void init(Settings settings)
        {
            _settings = settings;
        }
        public void Execute(DbManager dbInfo)
        {
            _configuration = dbInfo.Configuration;
            _dbInfo = dbInfo;
            comboBoxProvider.DataSource = Enum.GetValues(typeof(DataProviders));

            _cmbBoxServer.DataBindings.Add("Text", _dbInfo, "Server");
            if (_settings != null)
                textBoxWebUrl.Text = _settings.WebServiceUrl;
            if (_dbInfo.Authentication == Authentications.Windows)
            {
                _rdBtnWindows.Checked = true;
            }
            else if (dbInfo.Authentication == Authentications.Database)
            {
                _rdBtnDatabase.Checked = true;
            }
            else
            {
                throw new Exception("Unknown Authentication value");
            }
            AuthenticationChanged();
            _txtBoxUserName.DataBindings.Add("Text", _dbInfo, "User");
            _txtBoxPassword.DataBindings.Add("Text", _dbInfo, "Password");
            _cmbBoxDatabase.DataBindings.Add("Text", _dbInfo, "Database");
            comboBoxProvider.SelectedItem = _dbInfo.DatabaseType;
           
        }

        private void SetDataConnectionsBinding()
        {
            _cmbBoxServer.DataBindings.Add("Text", _dbInfo, "Server");
            _txtBoxUserName.DataBindings.Add("Text", _dbInfo, "User");
            _txtBoxPassword.DataBindings.Add("Text", _dbInfo, "Password");
            _cmbBoxDatabase.DataBindings.Add("Text", _dbInfo, "Database");
            _cmbBoxServer.Text = _dbInfo.Server;
            _txtBoxUserName.Text = _dbInfo.User;
            _txtBoxPassword.Text = _dbInfo.Password;
            _cmbBoxDatabase.Text = _dbInfo.Database;
        }

        public void Execute(Configuration configuration, bool isImport)
        {

            _configuration = configuration;

            _isImport = isImport;
            if (_configuration.DbInfo.Authentication == Authentications.Windows)
            {
                _rdBtnWindows.Checked = true;
            }
            else if (_configuration.DbInfo.Authentication == Authentications.Database)
            {
                _rdBtnDatabase.Checked = true;
            }
            else
            {
                throw new Exception("Unknown Authentication value");
            }
            IsPublished();
        }





        private void AuthenticationChanged()
        {
            if (_configuration != null && _dbInfo != null)
            {
                if (_rdBtnWindows.Checked)
                {
                    if (!_isImport)
                        _dbInfo.Authentication = Authentications.Windows;
                    else
                        _configuration.DbInfo.Authentication = Authentications.Windows;
                }
                else if (_rdBtnDatabase.Checked)
                {
                    if (!_isImport)
                        _dbInfo.Authentication = Authentications.Database;
                    else
                        _configuration.DbInfo.Authentication = Authentications.Database;
                }
            }
            //SetSqlServerConnection();
            _lblUserName.Enabled = _rdBtnDatabase.Checked;
            _txtBoxUserName.Enabled = _rdBtnDatabase.Checked;
            _lblPassword.Enabled = _rdBtnDatabase.Checked;
            _txtBoxPassword.Enabled = _rdBtnDatabase.Checked;
        }

        private void FrmDBConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_configuration != null && _dbInfo != null)
            {
                if (_isImport)
                {
                    _configuration.DbInfo.Server = _cmbBoxServer.Text;
                    //_configuration.DbInfo.Database = _cmbBoxDatabase.Text;
                    _configuration.Update();
                }
                else
                {
                    _dbInfo.Cancel();
                    Dispose();
                }
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                EnableControlsOnOK(false);
                _dbInfo.DatabaseType = (DataProviders)comboBoxProvider.SelectedItem;
                if (_isImport)
                {
                    DoImport();
                }
                else
                {
                    if (_dbInfo != null)
                    {
                        _dbInfo.Update();

                        if (IsPublish)
                        {
                            if (CheckUrlString(textBoxWebUrl.Text))
                            {
                                PostConnString(textBoxWebUrl.Text);
                                _settings.WebServiceUrl = textBoxWebUrl.Text;
                                MessageBox.Show("Database settings successfully published", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                SetControlAvailability(true);
                                DialogResult = DialogResult.None;
                            }

                        }
                        else

                            DialogResult = DialogResult.OK;
                    }





                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetControlAvailability(true);
            }
        }

        private void SetControlAvailability(bool availability)
        {
            _btnCancel.Enabled = availability;
            _btnTestConnection.Enabled = availability;
            _gpbDbInfo.Enabled = availability;
            _cmbBoxDatabase.Enabled = availability;
            _cmbBoxServer.Enabled = availability;
            _btnOk.Enabled = true;
        }

        private void EnableControlsOnOK(bool availability)
        {
            _btnOk.Enabled = availability;
            _btnTestConnection.Enabled = availability;
            _gpbDbInfo.Enabled = availability;
            _cmbBoxDatabase.Enabled = availability;
            _cmbBoxServer.Enabled = availability;
        }

        private void SetDbInfoValues()
        {
            if (_configuration != null)
            {
                _configuration.DbInfo.Server = _cmbBoxServer.Text;
                //_configuration.DbInfo.Database = _cmbBoxDatabase.Text;

                if (_rdBtnDatabase.Checked)
                {
                    _configuration.DbInfo.Authentication = Authentications.Database;
                    _configuration.DbInfo.Password = _txtBoxPassword.Text;
                    _configuration.DbInfo.User = _txtBoxUserName.Text;
                }
            }
        }

        private void DoImport()
        {
            if (_configuration != null)
            {
                SetDbInfoValues();
                DialogResult result = MessageBox.Show("Process has been completed successfully.\nDo you want to generate the forms now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Thread backgroundThread = new Thread(
                        new ThreadStart(() =>
                        {
                            int i = 1;
                            foreach (Questionaire sClass in _configuration.Questionaires)
                            {

                            }
                        }
                    ));
                    backgroundThread.SetApartmentState(ApartmentState.STA);
                    backgroundThread.Start();
                    this.Hide();
                }
                IsIgcx = false;
                _configuration.Cancel();
                _configuration.IsDirty = false;
                _configuration = null;
                ConfigurationCancelled = true;
                this.DialogResult = DialogResult.Cancel;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void _btnTestConnection_Click(object sender, EventArgs e)
        {
            if (!_isPublish)
            {
                if (_isImport)
                {
                    SetDbInfoValues();
                    //ConnectionTestResults connectionResults = _configuration.DbInfo.TestConnection(ConnectionTestTypes.ConnectivityTest);
                    //AnalyseConnectionTestResult(connectionResults);
                }
                else
                {
                    try
                    {
                        if (_dbInfo != null)
                        {
                            //_dbInfo.ValidateDb();
                            //using (new WaitCursor())
                            //    AnalyseConnectionTestResult(_dbInfo.TestConnection(ConnectionTestTypes.ConnectivityTest));
                        }

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                url = textBoxWebUrl.Text;
                if (CheckUrlString(url))
                    MessageBox.Show("Service is Up & Running", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AnalyseConnectionTestResult(ConnectionTestResults results)
        {
            string result = "Unknown result";
            bool isError = true;
            string caption = "Message";
            switch (results)
            {
                case ConnectionTestResults.ConnectionFailed:
                    result = "Connection attempt has failed";
                    caption = "Connection failed";
                    isError = true;
                    break;

                case ConnectionTestResults.ConnectionSucceeded:
                    result = "Connection attempt has succeeded";
                    caption = "Success";
                    isError = false;
                    break;

                case ConnectionTestResults.DatabasedoesnotExist:
                    result = "Database doesn't exist";
                    caption = "No database";
                    isError = false;
                    break;



                case ConnectionTestResults.DBNeedsToBeUpgraded:
                    result = "Database needs to be upgraded";
                    caption = "Upgrade";
                    isError = false;
                    break;

                case ConnectionTestResults.ErrorInConnection:
                    result = "An error has been encountered in the connection";
                    caption = "Error";
                    isError = true;
                    break;


            }

            if (isError)
                MessageBox.Show(result, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(result, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            if (_isImport)
            {
                _configuration.Cancel();
                _configuration.IsDirty = false;
                _configuration = null;
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void FrmDBConnect_Load(object sender, EventArgs e)
        {
            _btnCancel.Enabled = true;
            _btnTestConnection.Enabled = true;
            _gpbDbInfo.Enabled = true;
            _cmbBoxDatabase.Enabled = true;
            _cmbBoxServer.Enabled = true;
            if (_configuration != null && _dbInfo != null)
            {
                if (_isImport)
                {
                    _txtBoxUserName.Enabled = false;
                    _txtBoxPassword.Enabled = false;
                    _btnOk.Text = "Import";
                    _configuration.DbInfo.Server = _cmbBoxServer.Text;
                    _txtBoxUserName.DataBindings.Add("Text", _configuration.DbInfo, "User");
                    _txtBoxPassword.DataBindings.Add("Text", _configuration.DbInfo, "Password");

                    if (_configuration.DbInfo.Authentication == Authentications.Windows)
                    {
                        _rdBtnWindows.Checked = true;
                    }
                    else if (_configuration.DbInfo.Authentication == Authentications.Database)
                    {
                        _rdBtnDatabase.Checked = true;
                    }
                    else
                    {
                        throw new Exception("Unknown Authentication value");
                    }
                    AuthenticationChanged();
                }
            }
        }

        private void _rdBtnWindows_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationChanged();
        }

        private void _rdBtnDatabase_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationChanged();
        }

        private void _cmbBoxServer_DropDown(object sender, EventArgs e)
        {

        }

        private void _cmbBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _cmbBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_configuration.DbInfo.Database = _cmbBoxDatabase.Text;
        }

        private void PostConnString(string rootUrl)
        {
            string URL = rootUrl + "/api/configure/";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                //var connString = "=" + _dbInfo.ConnString;
                //wc.UploadString(URL, "POST", connString);
            }
        }

        private bool CheckUrlString(string rootUrl)
        {

            return _isCorrectUrl;
        }

        private void IsPublished()
        {
            if (!IsPublish)
            {
                _gpbServiceUrl.Visible = IsPublish;
                _gpbDbInfo.Location = _gpbServiceUrl.Location;
                _gpbDbInfo.Size = new Size(280, 323);
                this.Size = new Size(310, 420);
            }
        }

        private void _rdBtnWindows_CheckedChanged_1(object sender, EventArgs e)
        {
            AuthenticationChanged();
        }

        private void _btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void _btnOk_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void _rdBtnDatabase_CheckedChanged_1(object sender, EventArgs e)
        {
            AuthenticationChanged();
        }

    }
}
