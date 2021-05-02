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
    public partial class EnumListForm : Form
    {

        private EnumList _enumList;

        public EnumListForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        internal void PickValue(EnumList enumList)
        {
            _enumList = enumList;
            txtName.Text = _enumList.Name;
            RefreshGrid();
        }

        private void AddEnumValue()
        {
            EnumListValue enumListValue = _enumList.EnumValues.Add();
            EnumValueForm frm = new EnumValueForm();
            frm.PickValues(enumListValue);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            dataGridViewEnumValues.DataSource = null;
            dataGridViewEnumValues.DataSource = _enumList.EnumValues.List;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddEnumValue();
        }

        private void AssignValues()
        {
            _enumList.Name = txtName.Text;
        }

        private void SaveAndClose()
        {
            AssignValues();
            _enumList.Update();
            DialogResult = DialogResult.OK;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

    }
}
