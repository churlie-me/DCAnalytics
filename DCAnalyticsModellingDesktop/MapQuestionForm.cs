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
    public partial class MapQuestionForm : Form
    {

        private MapQuestion _mapQuestion;
        private bool _isCancelling;

        public MapQuestionForm()
        {
            InitializeComponent();
        }

        internal void PickValues(MapQuestion openQuestion)
        {
            _mapQuestion = openQuestion;
          
            textBoxQuestionText.Text = _mapQuestion.QuestionText;
            textBoxName.Text = _mapQuestion.Name;
          
        }
        private void Save()
        {
            _isCancelling = true;
            AssignValues();
            _mapQuestion.Update();
            DialogResult = DialogResult.OK;
        }


        private void AssignValues()
        {
            _mapQuestion.QuestionText = textBoxQuestionText.Text;
            _mapQuestion.Name = textBoxName.Text;
            
        }

        private void OnClosingForm(FormClosingEventArgs e)
        {
            try
            {
                if (_isCancelling) return;
                AssignValues();
                if (_mapQuestion.ObjectState != ObjectStates.None)
                {
                    var isYes = MessageBox.Show("Do you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (isYes)
                    {
                        _mapQuestion.Update();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _mapQuestion.Cancel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void MapQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosingForm(e);
        }

    }
}
