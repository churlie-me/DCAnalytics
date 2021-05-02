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
    public partial class SectionForm : Form
    {
        private Section _section;
        private bool _isCancelling;
        public SectionForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        internal void PickValues(Section section)
        {
            _section = section;
            textBoxName.Text = _section.Name;
            RefreshSubSections();
            RefreshQuestions();
        }

        private void RefreshSubSections()
        {
            dataGridViewSections.DataSource = null;
            dataGridViewSections.DataSource = _section.SubSections.List;
        }

        private void RefreshQuestions()
        {
            dataGridViewQuestions.DataSource = null;
            dataGridViewQuestions.DataSource = _section.Questions.List;
        }

        private void AddSubSection()
        {
            SubSection subSection = _section.SubSections.Add();
            SubSectionForm subSectionForm = new SubSectionForm();
            subSectionForm.PickValues(subSection);
            if (subSectionForm.ShowDialog() == DialogResult.OK)
                RefreshSubSections();
        }

        private void AddQuestion(QuestionTypes questionType)
        {
            switch (questionType)
            {
                case QuestionTypes.Closed:
                    ClosedQuestion questionaire = (ClosedQuestion)_section.Questions.Add(questionType);
                    break;
            }

        }

        private void AddClosedQuestion()
        {
            ClosedQuestion closedQuestion = (ClosedQuestion)_section.Questions.Add(QuestionTypes.Closed);
            ChoiceQuestionForm closedQnFrm = new ChoiceQuestionForm();
            closedQnFrm.PickValues(closedQuestion);
            closedQnFrm.ShowDialog();
            RefreshQuestions();
        }

        private void toolStripButtonAddQuestion_Click(object sender, EventArgs e)
        {

        }

        private void AssignValues()
        {
            _section.Name = textBoxName.Text;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            _isCancelling = true;
            AssignValues();
            DialogResult = DialogResult.OK;
        }

        private void AddOpenQuestion()
        {
            OpenQuestion openQuestion = _section.Questions.AddOpenQuestion();
            OpenQuestionForm form = new OpenQuestionForm();
            form.PickValues(openQuestion);
            if(form.ShowDialog()== DialogResult.OK)
            {
                RefreshQuestions();
            }
        }

        private void openQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOpenQuestion();
        }

        private void toolStripButtonAddSection_Click(object sender, EventArgs e)
        {
            AddSubSection();
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
                if (_section.ObjectState != ObjectStates.None)
                {
                    var isYes = MessageBox.Show("Do you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (isYes)
                    {
                        _section.Update();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _section.Cancel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void CancelStuff()
        {
            _isCancelling = true;
            _section.Cancel();
            DialogResult = DialogResult.Cancel;
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            CancelStuff();
        }

        private void toolStripButtonAddTransition_Click(object sender, EventArgs e)
        {
            AddTransitionCondition();
        }

        private void AddTransitionCondition()
        {
            TransitionCondition condition = _section.TransitionConditions.Add();
            TransitionConditionBuilder transitionConditionBuilder = new TransitionConditionBuilder(condition);
            transitionConditionBuilder.ShowDialog();
        }

       

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void SectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosingForm(e);
        }
        private void AddMapQuestion()
        {       
            MapQuestion mapQn = (MapQuestion)_section.Questions.Add(QuestionTypes.Map);
            MapQuestionForm MapQnFrm = new MapQuestionForm();
            MapQnFrm.PickValues(mapQn);
            if (MapQnFrm.ShowDialog() == DialogResult.OK)
            {
                RefreshQuestions();
            }
        }

        private void mapQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMapQuestion();
        }

    }
}
