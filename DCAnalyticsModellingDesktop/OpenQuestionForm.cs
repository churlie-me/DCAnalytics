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
    public partial class OpenQuestionForm : Form
    {
        private OpenQuestion _openQuestion;

        public OpenQuestionForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        internal void PickValues(OpenQuestion openQuestion)
        {
            _openQuestion = openQuestion;
            comboBoxDataType.DataSource = Enum.GetValues(typeof(DataTypes));
            textBoxQuestionText.Text = _openQuestion.QuestionText;
            textBoxName.Text = _openQuestion.Name;
            checkBoxIsBinary.Checked = _openQuestion.IsBinaryAnswer;
            comboBoxDataType.SelectedItem = _openQuestion.DataType;
        }

        private void OpenQuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Save()
        {
            _isCancelling = true;
            AssignValues();
            _openQuestion.Update();
            DialogResult = DialogResult.OK;
        }

       
        private void AssignValues()
        {
            _openQuestion.QuestionText = textBoxQuestionText.Text;
            _openQuestion.Name = textBoxName.Text;
            _openQuestion.IsBinaryAnswer = checkBoxIsBinary.Checked;
            _openQuestion.DataType = (DataTypes)comboBoxDataType.SelectedItem;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool _isCancelling;

        private void OnClosingForm(FormClosingEventArgs e)
        {
            try
            {
                if (_isCancelling) return;
                AssignValues();
                if (_openQuestion.ObjectState != ObjectStates.None)
                {
                    var isYes = MessageBox.Show("Do you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (isYes)
                    {
                        _openQuestion.Update();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _openQuestion.Cancel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void OpenQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosingForm(e);
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            _isCancelling = true;
            _openQuestion.Cancel();
            DialogResult = DialogResult.Cancel;
        }

    }
}
