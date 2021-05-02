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
    public partial class EnumValueForm : Form
    {
        private bool _isCancelling;
        private EnumListValue _enumListValue;

        public EnumValueForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        internal void PickValues(EnumListValue enumListValue)
        {
            _enumListValue = enumListValue;
        }

        private void EnumValueForm_Load(object sender, EventArgs e)
        {

        }

        private void AssignValues()
        {
            _enumListValue.Description = TextBoxEnumValueName.Text;
            if (!string.IsNullOrWhiteSpace(textBoxEnumValue.Text))
            {
                int val;
                if (int.TryParse(textBoxEnumValue.Text, out val))
                    _enumListValue.Code = val;
                else
                    throw new Exception("Code should be an integer");
            }
        }

        private void SaveAndClose()
        {
            try
            {
                AssignValues();
                _enumListValue.Update();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnClosingForm(FormClosingEventArgs e)
        {
            try
            {
                if (_isCancelling) return;
                AssignValues();
                if (_enumListValue.ObjectState != ObjectStates.None)
                {
                    var isYes = MessageBox.Show("Do you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (isYes)
                    {
                        _enumListValue.Update();
                    }
                    else
                    {
                        _enumListValue.Cancel();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }


        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void EnumValueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosingForm(e);
        }

        private void CancelStuff()
        {
            _isCancelling = true;
            _enumListValue.Cancel();
            DialogResult = DialogResult.Cancel;
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            CancelStuff();
        }

    }
}
