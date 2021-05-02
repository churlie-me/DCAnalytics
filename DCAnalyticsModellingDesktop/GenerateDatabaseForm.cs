using DCAnalytics.Data;
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
    public partial class GenerateDatabaseForm : Form
    {
        private dloDataApplication _dataApplication;
        public GenerateDatabaseForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        internal void PickQueries(dloDataApplication application)
        {
            _dataApplication = application;
            LoadQueriesGrid();
        }

        private void LoadQueriesGrid()
        {
            dataGridViewQueries.DataSource = null;
            dataGridViewQueries.DataSource = _dataApplication.Queries.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ExecuteQueries()
        {
            try
            {
                _dataApplication.ExecuteQueries();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            ExecuteQueries();
        }

    }
}
