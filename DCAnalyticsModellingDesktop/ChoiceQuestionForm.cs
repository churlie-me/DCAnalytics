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
    public partial class ChoiceQuestionForm : Form
    {

        private ChoiceQuestion _choiceQuestion;
        private bool _isCancelling;
        public ChoiceQuestionForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        internal void PickValues(ChoiceQuestion choiceQuestion)
        {
            _choiceQuestion = choiceQuestion;
            textBoxQuestionText.Text = _choiceQuestion.QuestionText;
            textBoxName.Text = _choiceQuestion.Name;
            if (_choiceQuestion.EnumList != null)
            {
                if (_choiceQuestion.Configuration.EnumerationLists.Contains(_choiceQuestion.EnumList))
                    comboBoxAnswerList.SelectedItem = _choiceQuestion.EnumList;
            }
        }
        private void AddSkipCondition()
        {
            SkipCondition skipCondition = _choiceQuestion.Conditions.Add();
            SkipConditionBuilder skipConditionBuilder = new SkipConditionBuilder(skipCondition);
            if (skipConditionBuilder.ShowDialog() == DialogResult.OK)
                RefreshSkipConditions();
        }

        private void LoadCombobox()
        {
            //comboBoxAnswerList.DataSource = _closedQuestion.Configuration.EnumerationLists.ToList();   
            foreach (var c in _choiceQuestion.Configuration.EnumerationLists)
            {
                comboBoxAnswerList.Items.Add(c);
            }
            comboBoxAnswerList.DisplayMember = "Name";
        }

        private void ClosedQuestionForm_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void AssignValues()
        {
            _choiceQuestion.QuestionText = textBoxQuestionText.Text;
            _choiceQuestion.Name = textBoxName.Text;
            _choiceQuestion.EnumList = (EnumList)comboBoxAnswerList.SelectedItem;
        }

        private void SaveAndClose()
        {
            _isCancelling = true;
            AssignValues();
            _choiceQuestion.Update();
            DialogResult = DialogResult.OK;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void OnClosingForm(FormClosingEventArgs e)
        {
            try
            {
                if (_isCancelling) return;
                AssignValues();
                if (_choiceQuestion.ObjectState != ObjectStates.None)
                {
                    var isYes = MessageBox.Show("Do you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (isYes)
                    {
                        _choiceQuestion.Update();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _choiceQuestion.Cancel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void ChoiceQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosingForm(e);
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            _isCancelling = true;
            _choiceQuestion.Cancel();
            DialogResult = DialogResult.Cancel;
        }

        private void RefreshSkipConditions()
        {
            dataGridViewSkipConditions.DataSource = null;
            dataGridViewSkipConditions.DataSource = _choiceQuestion.Conditions.ToList();
        }

        private void toolStripButtonAddSkipCondition_Click(object sender, EventArgs e)
        {
            AddSkipCondition();
        }

    }
}
