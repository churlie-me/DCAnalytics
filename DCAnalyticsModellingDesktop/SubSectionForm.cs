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
    public partial class SubSectionForm : Form
    {

        private SubSection _subSection;
        private bool _isCancelling;
        public SubSectionForm()
        {
            InitializeComponent();
            CenterToScreen();
        }
        
        private void RefreshQuestions()
        {
            dataGridViewQuestions.DataSource = null;
            dataGridViewQuestions.DataSource = _subSection.Questions.ToList();
        }

        internal void PickValues(SubSection subSection)
        {
            _subSection = subSection;
        }

        private void AddOpenQuestion()
        {
            OpenQuestion openQuestion = _subSection.Questions.AddOpenQuestion();
            OpenQuestionForm form = new OpenQuestionForm();
            form.PickValues(openQuestion);
            form.ShowDialog();
            RefreshQuestions();
        }

        private void openQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOpenQuestion();
        }

        private void AssignValues()
        {
            _subSection.Name = textBoxName.Text;
        }
        private void Save()
        {
            _isCancelling = true;
            AssignValues();
            _subSection.Update();
            DialogResult = DialogResult.OK;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void AddClosedQuestion()
        {
            ClosedQuestion closedQuestion = (ClosedQuestion)_subSection.Questions.Add(QuestionTypes.Closed);
            ChoiceQuestionForm closedQnFrm = new ChoiceQuestionForm();
            closedQnFrm.PickValues(closedQuestion);
            closedQnFrm.ShowDialog();
            RefreshQuestions();
        }

        private void closedQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClosedQuestion();
        }

        private void OnClosingForm(FormClosingEventArgs e)
        {
            try
            {
                if (_isCancelling) return;
                AssignValues();
                if (_subSection.ObjectState != ObjectStates.None)
                {
                    var isYes = MessageBox.Show("Do you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (isYes)
                    {
                        _subSection.Update();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _subSection.Cancel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void SubSectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosingForm(e);
        }

        private void CancelStuff()
        {
            _isCancelling = true;
            _subSection.Cancel();
            DialogResult = DialogResult.Cancel;
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            CancelStuff();
        }

    }
}
