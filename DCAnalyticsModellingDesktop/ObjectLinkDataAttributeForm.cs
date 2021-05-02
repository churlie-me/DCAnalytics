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
    public partial class ObjectLinkDataAttributeForm : Form
    {
        public ObjectLinkDataAttributeForm()
        {
            InitializeComponent();
        }

        private void BindComboBox()
        {
            List<string> sjsjs = new List<string>();
            comboBox1.BindingContext = new BindingContext();
            comboBox1.DataSource = sjsjs;

            comboBox1.BindingContext[sjsjs, "OID"].Position = 1;

            

        }

    }
}
