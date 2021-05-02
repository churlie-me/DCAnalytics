using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCAnalytics;

namespace DCAnalyticsModellingDesktop
{
    public partial class QuestionaireForm : Form
    {

        private Questionaire _questionaire;

        public QuestionaireForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        internal void PickValues(Questionaire questionaire)
        {
            _questionaire = questionaire;
            Init();
        }

   

        private void Init()
        {
            DoBinding();
        }

        private void DoBinding()
        {
            textBoxName.DataBindings.Add("Text", _questionaire, "Name");
            RefreshSectionsGrid();
        }

        private void RefreshSectionsGrid()
        {
            dataGridViewSections.DataSource = null;
            dataGridViewSections.DataSource = _questionaire.Sections.List;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            _isCancelling = true;
            _questionaire.Name = textBoxName.Text;
            DialogResult = DialogResult.OK;
        }

        private void AddSection()
        {
            Section section = _questionaire.Sections.Add();
            SectionForm sectionForm = new SectionForm();
            sectionForm.PickValues(section);
            if(sectionForm.ShowDialog() == DialogResult.OK)
            {
                RefreshSectionsGrid();
            }
        }

        private void toolStripButtonAddSection_Click(object sender, EventArgs e)
        {
            AddSection();
        }

        private void AssignValues()
        {
            _questionaire.Name = textBoxName.Text;
        }

        private bool _isCancelling;
        private void OnClosingForm(FormClosingEventArgs e)
        {
            try
            {
                if (_isCancelling) return;
                AssignValues();
                if (_questionaire.ObjectState != ObjectStates.None)
                {
                    var isYes = MessageBox.Show("Do you want to save changes", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (isYes)
                    {
                        _questionaire.Update();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _questionaire.Cancel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void QuestionaireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosingForm(e);
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            _isCancelling = true;
            _questionaire.Cancel();
            DialogResult = DialogResult.Cancel;
        }

    }
}
