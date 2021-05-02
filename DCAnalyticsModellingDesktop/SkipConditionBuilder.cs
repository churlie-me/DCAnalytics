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
    public partial class SkipConditionBuilder : Form
    {
        private SkipCondition _condition;
        public SkipConditionBuilder(SkipCondition condition)
        {
            InitializeComponent();
            _condition = condition;
            Bind();
        }

        private void Bind()
        {

            _cmbQualifier.Format += new ListControlConvertEventHandler(_cmbQualifier_Format);
            _cmbQualifier.DataSource = Enum.GetValues(typeof(Qualifiers));
            _cmbQualifier.SelectedItem = _condition.Qualifier;

            // var fields = from x in _condition.Parent.Parent.Parent.Parent.Attributes where x.Key != _condition.Parent.Parent.Key && !x.IsSystem select x;
            var isQn = _condition.Parent.Parent is Question;
            Question qn = null;
            if (isQn)
            {
                qn = _condition.Parent.Parent as Question;
            }

            comboBoxEnums.DataSource = _condition.Configuration.EnumerationLists.List;
            comboBoxEnums.DisplayMember = "Name";
          
            List<DataCollectionObject> objs = new List<DataCollectionObject>();

            foreach (var c in _condition.Configuration.Questionaires)
            {
                foreach (var s in c.Sections)
                {
                    if ((qn.Parent.Parent as Section) != null && (qn.Parent.Parent as Section).Equals(s))
                    {
                        objs.Add(s);
                        foreach (var q in s.Questions)
                        {
                            objs.Add(q);
                        }
                        foreach (var sb in s.SubSections)
                        {
                            objs.Add(sb);
                            foreach (var q1 in sb.Questions)
                            {
                                objs.Add(q1);
                            }
                        }
                    }
                }
            }

            comboBoxSkipTo.DataSource = null;
            comboBoxSkipTo.DataSource = (qn.Parent.Parent as Section).Questions;
            comboBoxSkipTo.DisplayMember = "Name";
        }

        void _cmdField_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_condition.Attribute = _cmbField.SelectedItem as DataAttribute;
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
                _condition.Qualifier = (Qualifiers)_cmbQualifier.SelectedItem;
                _condition.Answer = comboBoxAnswers.SelectedItem as EnumListValue;
                _condition.Target = comboBoxSkipTo.SelectedItem as DataCollectionObject;
                _condition.EnumList = comboBoxEnums.SelectedItem as EnumList;
                // _condition.Question = _cmbQuestions.SelectedItem as Question;
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

        private void LoadAnswers()
        {
            //if (_cmbQuestions.SelectedItem == null) return;
            //ClosedQuestion closedQuestion = _cmbQuestions.SelectedItem as ClosedQuestion;
            //comboBoxAnswers.DataSource = null;
            //comboBoxAnswers.DataSource = (_condition.Parent.Parent as ClosedQuestion).EnumList.EnumValues.List;
            //comboBoxAnswers.DisplayMember = "Description";
        }

        private void _cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadAnswers();
        }

        private void comboBoxEnums_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAnswers.DataSource = (comboBoxEnums.SelectedItem as EnumList).EnumValues.List;
            comboBoxAnswers.DisplayMember = "Description";

        }
    }
}
