using DCAnalytics;
using Datalabs;
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
    public partial class TransitionConditionBuilder : Form
    {
        private TransitionCondition _condition;
        public TransitionConditionBuilder(TransitionCondition condition)
        {
            InitializeComponent();
            _condition = condition;
            Bind();
            CenterToScreen();
        }

        private void Bind()
        {
            _txtValidationValue.DataBindings.Add("Text", _condition, "ValidationValue");

            radioPanel1.ValueMember = "TransitionType";
            radioPanel1.DataSource = _condition;

            _cmbQualifier.Format += new ListControlConvertEventHandler(_cmbQualifier_Format);
            _cmbQualifier.DataSource = Enum.GetValues(typeof(Qualifiers));
            _cmbQualifier.SelectedItem = _condition.Qualifier;

            _cmbValidationType.Format += _cmbValidationType_Format;
            _cmbValidationType.DataSource = Enum.GetValues(typeof(ValidationTypes));
            _cmbValidationType.SelectedItem = _condition.ValidationType;




            var forms = from x in _condition.Configuration.Questionaires.Cast<Questionaire>()                   
                        select x;

            List<DCAnalyticsObject> objs = new List<DCAnalyticsObject>();

            foreach(var f in forms.Cast<Questionaire>())
            {
                objs.AddRange(f.Sections);
                foreach (var sb in f.Sections)
                {
                    objs.AddRange(sb.SubSections);
                    objs.AddRange(sb.Questions);
                    foreach(var ss in sb.SubSections)
                    {
                        objs.AddRange(ss.Questions);
                    }
                }              
            }

            _cmbForm.DataSource = objs;
            _cmbForm.DisplayMember = "Name";
            _cmbForm.SelectedItem = _condition.DataObject;
            _cmbForm.SelectedIndexChanged += _cmbForm_SelectedIndexChanged;


            var questions = from x in _condition.Parent.Parent.Questions where x.QuestionType == QuestionTypes.Closed  select x;
            _cmbQuestions.DisplayMember = "Name";
            _cmbQuestions.DataSource = questions.ToList();
           
            //_cmbQuestions.SelectedItem = _condition.Attribute;
            _cmbQuestions.SelectedIndexChanged += _cmbField_SelectedIndexChanged;
        }

        private void LoadAnswers()
        {
            ClosedQuestion closedQuestion = _cmbQuestions.SelectedItem as ClosedQuestion;
            comboBoxAnswers.DisplayMember = "Code";
            comboBoxAnswers.DataSource = closedQuestion.EnumList.EnumValues.List;           
        }

        void _cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAnswers();
        }

        void _cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_condition.DataObject = _cmbForm.SelectedItem as DataCollectionObject;
        }

        void _cmbValidationType_Format(object sender, ListControlConvertEventArgs e)
        {
            ValidationTypes types = (ValidationTypes)e.ListItem;
            e.Value = Enum.GetName(typeof(ValidationTypes), types);
        }

        void _cmbQualifier_Format(object sender, ListControlConvertEventArgs e)
        {
            Qualifiers qualifier = (Qualifiers)e.ListItem;
            e.Value = Enum.GetName(typeof(Qualifiers), qualifier);
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_condition.ValidationValue) && _condition.TransitionType==TransitionTypes.ConditionalNavigation)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to proceed without setting a value to test for?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                _condition.Qualifier = (Qualifiers)_cmbQualifier.SelectedItem;
                _condition.ValidationType = (ValidationTypes)_cmbValidationType.SelectedItem;

                _condition.Update();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _condition.Cancel();
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox1.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
            }
        }

        private void _cmbForm_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawImage(Image.FromFile(""), e.Bounds.Left, e.Bounds.Top);
        }

    }
}
