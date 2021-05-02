using DCAnalytics.Data;
using DCAnalytics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCAnalyticsModellingDesktop
{
    public partial class Main : Form
    {

        #region members 
        private SolutionExplorer _solutionExplorer;
        private Configuration _configuration;
        #endregion

        #region properties
        internal Configuration Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                if (_configuration == null)
                {
                    _configuration = value;
                    //build tree
                    BuildTree();

                }
            }
        }

        internal TreeView Tree
        {
            get
            {
                return _solutionExplorer.TreeView;
            }
        }


        #endregion
        public Main()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
        }

        private void Initialize()
        {
            _solutionExplorer = new SolutionExplorer();
            _solutionExplorer.TreeView.ImageList = this.imageList1;
            _solutionExplorer.TreeView.NodeMouseClick += TreeView_NodeMouseClick;
            Tree.MouseDoubleClick += Tree_MouseDoubleClick;
            //dock solutionexploer
            _solutionExplorer.Show(_dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            //Disable
            DisableControls();
        }

        private void EditEnumList(MouseEventArgs e)
        {
            TreeNode node = Tree.GetNodeAt(e.X, e.Y);
            if (node.Tag is EnumList)
            {
                EnumList enumList = node.Tag as EnumList;
                EnumListForm enumListForm = new EnumListForm();
                enumListForm.PickValue(enumList);
                enumListForm.ShowDialog();
            }
        }


        private void OnDoubleClick(MouseEventArgs e)
        {
            EditEnumList(e);
            EditSection(e);
            EditQuestion(e);
        }

        private void Tree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnDoubleClick(e);
        }

        private void DisableControls()
        {
            if (_configuration != null) return;
            _solutionExplorer.DisableTree();
        }

        private void BuildTree()
        {
            _solutionExplorer.TreeView.Nodes.Clear();

            TreeNode rootNode = _solutionExplorer.TreeView.Nodes.Add("Configuration");
            rootNode.Tag = _configuration;

            rootNode.Text = _configuration.FileName;

            TreeNode dataCollectionObjects = rootNode.Nodes.Add("Data Collection Objects");
            dataCollectionObjects.Tag = _configuration.Questionaires;


            TreeNode questionnaires = dataCollectionObjects.Nodes.Add("Questionnaires");


            TreeNode userRights = _solutionExplorer.TreeView.Nodes.Add("User Rights");

            TreeNode providers = _solutionExplorer.TreeView.Nodes.Add("Data Caches");

            TreeNode enumLists = _solutionExplorer.TreeView.Nodes.Add("Enum Lists");
            enumLists.Tag = _configuration.EnumerationLists;


            TreeNode purchasesNode = _solutionExplorer.TreeView.Nodes.Add("Purchases");

            TreeNode cerificationsNode = _solutionExplorer.TreeView.Nodes.Add("Certifications");

            TreeNode trainingsNode = _solutionExplorer.TreeView.Nodes.Add("Trainings");

            AddEnumerationListNodes(enumLists);


            AddQuestionaireNodes(questionnaires);

            _solutionExplorer.TreeView.ExpandAll();

        }

        private void AddEnumerationListNodes(TreeNode enumLists)
        {
            foreach (var enumList in _configuration.EnumerationLists)
            {
                TreeNode treeNode = enumLists.Nodes.Add(enumList.Name);
                treeNode.Tag = enumList;
            }
        }


        private void AddQuestionaireNodes(TreeNode questionnaires)
        {
            foreach (var questionaire in _configuration.Questionaires)
            {
                if (questionaire.CollectionObjectType != DataCollectionObectTypes.Questionaire) continue;
                var questionaireNode = AddToParentNode(questionnaires, questionaire, questionaire.Name);
                questionaireNode.Tag = questionaire as Questionaire;
                AddQuestionaireChildNodes(questionaireNode);
                questionaireNode.ImageIndex = 9;
                questionaireNode.SelectedImageIndex = 9;
            }
        }


        private void CreateConfiguration()
        {
            _configuration = new Configuration();
            _solutionExplorer.EnableTree();
            BuildTree();
        }

        private void AddDataCollectionObject()
        {

        }

        private void EditDataCollectionObject()
        {

        }

        private void AddSimpleDataAttribute()
        {

        }

        private void AddObjectlinkAttribute()
        {

        }

        private void AddTransitionLink()
        {

        }

        private void ribbonButtonNew_Click(object sender, EventArgs e)
        {
            CreateConfiguration();
        }

        private void OpenConfiguration()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "json files|*.js";
                var isOk = ofd.ShowDialog() == DialogResult.OK;
                if (isOk)
                {
                    if (_configuration != null)
                        _configuration = null;

                    _configuration = Configuration.OpenFile(ofd.FileName);

                    Text = ofd.FileName;
                    _configuration.FileName = ofd.FileName;
                    _configuration.Name = Path.GetFileNameWithoutExtension(ofd.FileName);

                    BuildTree();
                    //enable
                    _solutionExplorer.EnableTree();
                }
            }
        }

        private string LaunchSaveDialog()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                var isOk = saveFileDialog.ShowDialog() == DialogResult.OK;
                if (isOk)
                {
                    return saveFileDialog.FileName;
                }
            }
            return "";
        }

        private void SaveConfiguration()
        {
            if (_configuration == null) return;
            var missing = string.IsNullOrWhiteSpace(_configuration.FileName);
            if (missing)
            {
                //save as
                var fileName = LaunchSaveDialog();
                _configuration.FileName = fileName + ".json";
            }
            _configuration.Save();
        }

        private void ribbonButtonOpen_Click(object sender, EventArgs e)
        {
            OpenConfiguration();
        }

        private void ribbonButtonSave_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void AddQuestionaire()
        {
            if (Tree.SelectedNode == null) return;
            if (Tree.SelectedNode.Text != "Questionnaires") return;
            Questionaire questionaire = (Questionaire)_configuration.Questionaires.Add();
            QuestionaireForm frm = new QuestionaireForm();
            frm.PickValues(questionaire);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var questionaireNode = AddToParentNode(Tree.SelectedNode, questionaire, questionaire.Name);
                questionaireNode.Tag = questionaire;
                AddQuestionaireChildNodes(questionaireNode);
                questionaireNode.ImageIndex = 9;
                questionaireNode.SelectedImageIndex = 9;
            }
        }

        private TreeNode SearchNodes(string key, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == key)
                {
                    return node;
                }
                else
                {
                    if (node.Nodes.Count > 0)
                    {
                        return SearchNodes(key, node.Nodes);
                    }
                }
            }
            return null;
        }
        private void AddSection()
        {
            if (Tree.SelectedNode == null) return;
            if (Tree.SelectedNode.Text != "Sections") return;
            Questionaire questionnaire = Tree.SelectedNode.Parent.Tag as Questionaire;
            Section section = questionnaire.Sections.Add();
            SectionForm sectionForm = new SectionForm();
            sectionForm.PickValues(section);
            sectionForm.ShowDialog();
            var sectionNode = AddToParentNode(Tree.SelectedNode, section, section.Name);
            sectionNode.Tag = section;
            AddSectionSubNodes(sectionNode);
            sectionNode.ImageIndex = 7;
            sectionNode.SelectedImageIndex = 7;
        }

        private void EditSection(MouseEventArgs e)
        {
            TreeNode treeNode = Tree.GetNodeAt(e.X, e.Y);

            if (!(treeNode.Tag is Section)) return;

            Section section = treeNode.Tag as Section;
            SectionForm sectionForm = new SectionForm();
            sectionForm.PickValues(section);
            sectionForm.ShowDialog();
            treeNode.Text = section.Name;
        }

        private void EditQuestion(MouseEventArgs e)
        {
            TreeNode treeNode = Tree.GetNodeAt(e.X, e.Y);

            if (!(treeNode.Tag is Question)) return;
            Question question = treeNode.Tag as Question;
            switch (question.QuestionType)
            {
                case QuestionTypes.Closed:
                    ChoiceQuestionForm form = new ChoiceQuestionForm();
                    form.PickValues(question as ClosedQuestion);
                    if (form.ShowDialog() == DialogResult.OK)
                        treeNode.Text = question.Name;
                    break;
                case QuestionTypes.MultipleChoice:
                    ChoiceQuestionForm formM = new ChoiceQuestionForm();
                    formM.PickValues(question as MultipleChoiceQuestion);
                    if (formM.ShowDialog() == DialogResult.OK)
                        treeNode.Text = question.Name;
                    break;
                case QuestionTypes.Open:
                    OpenQuestionForm formOpen = new OpenQuestionForm();
                    formOpen.PickValues(question as OpenQuestion);
                    if (formOpen.ShowDialog() == DialogResult.OK)
                        treeNode.Text = question.Name;
                    break;
            }
        }

        private void AddSubSection()
        {
            if (Tree.SelectedNode == null) return;
            if (Tree.SelectedNode.Text != "Sub Sections") return;
            Section section = Tree.SelectedNode.Parent.Tag as Section;
            SubSection subSection = section.SubSections.Add();
            SubSectionForm subSectionForm = new SubSectionForm();
            subSectionForm.PickValues(subSection);
            subSectionForm.ShowDialog();
            var subSectionTreeNode = AddToParentNode(Tree.SelectedNode, subSection, subSection.Name);
            subSectionTreeNode.Tag = subSection;

            foreach (var qn in subSection.Questions)
            {
                TreeNode questionsNode = subSectionTreeNode.Nodes.Add("Questions");
                questionsNode.Tag = subSection.Questions;
                TreeNode questionNode = questionsNode.Nodes.Add(qn.Name);
                questionNode.Tag = qn;
                switch (qn.QuestionType)
                {
                    case QuestionTypes.Closed:
                        questionNode.ImageIndex = 6;
                        questionNode.SelectedImageIndex = 6;
                        break;
                    case QuestionTypes.Open:
                        questionNode.ImageIndex = 3;
                        questionNode.SelectedImageIndex = 3;
                        break;
                    case QuestionTypes.MultipleChoice:
                        questionNode.ImageIndex = 10;
                        questionNode.SelectedImageIndex = 10;
                        break;
                }
            }

            subSectionTreeNode.ImageIndex = 8;
            subSectionTreeNode.SelectedImageIndex = 8;


        }

        private void AddSectionSubNodes(TreeNode sectionNode)
        {
            Section section = sectionNode.Tag as Section;
            TreeNode questionsNode = sectionNode.Nodes.Add("Questions");
            questionsNode.Tag = section.Questions;

            TreeNode subSectionsNode = sectionNode.Nodes.Add("Sub Sections");
            subSectionsNode.Tag = section.SubSections;

            foreach (var qn in section.Questions)
            {
                TreeNode questionNode = questionsNode.Nodes.Add(qn.Name);
                questionNode.Tag = qn;
                switch (qn.QuestionType)
                {
                    case QuestionTypes.Closed:
                        questionNode.ImageIndex = 6;
                        questionNode.SelectedImageIndex = 6;
                        break;
                    case QuestionTypes.Open:
                        questionNode.ImageIndex = 3;
                        questionNode.SelectedImageIndex = 3;
                        break;
                    case QuestionTypes.MultipleChoice:
                        questionNode.ImageIndex = 10;
                        questionNode.SelectedImageIndex = 10;
                        break;
                }
            }

            foreach (var subSection in section.SubSections)
            {
                TreeNode subSectionTreeNode = subSectionsNode.Nodes.Add(subSection.Name);
                subSectionsNode.Tag = subSection;
                foreach (var qn in subSection.Questions)
                {
                    questionsNode = subSectionTreeNode.Nodes.Add("Questions");
                    questionsNode.Tag = subSection.Questions;
                    TreeNode questionNode = questionsNode.Nodes.Add(qn.Name);
                    questionNode.Tag = qn;
                    switch (qn.QuestionType)
                    {
                        case QuestionTypes.Closed:
                            questionNode.ImageIndex = 6;
                            questionNode.SelectedImageIndex = 6;
                            break;
                        case QuestionTypes.Open:
                            questionNode.ImageIndex = 3;
                            questionNode.SelectedImageIndex = 3;
                            break;
                        case QuestionTypes.MultipleChoice:
                            questionNode.ImageIndex = 10;
                            questionNode.SelectedImageIndex = 10;
                            break;
                    }
                }

                subSectionTreeNode.ImageIndex = 8;
                subSectionTreeNode.SelectedImageIndex = 8;

            }

        }


        private TreeNode AddToParentNode(TreeNode parentNode, DCAnalyticsObject obj, string objName)
        {
            TreeNode node = parentNode.Nodes.Add(objName);
            node.Tag = obj;
            node.ExpandAll();
            return node;
        }

        private void AddQuestionaireChildNodes(TreeNode quesionaireNode)
        {
            TreeNode sectionNodes = quesionaireNode.Nodes.Add("Sections");
            sectionNodes.Tag = (quesionaireNode.Tag as Questionaire).Sections;
            Questionaire questionaire = quesionaireNode.Tag as Questionaire;
            foreach (Section section in questionaire.Sections)
            {
                TreeNode sectionNode = sectionNodes.Nodes.Add(section.Name);
                sectionNode.Tag = section;
                AddSectionSubNodes(sectionNode);
                sectionNode.ImageIndex = 7;
                sectionNode.SelectedImageIndex = 7;
            }
        }

        private void questionaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddQuestionaire();
        }

        private void ShowTreeContextMenu(TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;
            if (Tree.SelectedNode == null) return;
            contextMenuStripTree.Show(Cursor.Position);
            enumListToolStripMenuItem.Enabled = false;

            if (Tree.SelectedNode.Text == "Enum Lists")
            {
                enumListToolStripMenuItem.Enabled = true;
            }

        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowTreeContextMenu(e);
        }

        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSection();
        }

        private void AddOpenQuestion()
        {
            if (!(Tree.SelectedNode.Tag is Questions)) return;
            Questions questions = Tree.SelectedNode.Tag as Questions;
            OpenQuestion openQuestion = (OpenQuestion)questions.Add(QuestionTypes.Open);
            OpenQuestionForm openQnFrm = new OpenQuestionForm();
            openQnFrm.PickValues(openQuestion);
            if (openQnFrm.ShowDialog() == DialogResult.OK)
            {
                TreeNode questionsNode = Tree.SelectedNode;
                if (questionsNode != null)
                {
                    var questionNode = AddToParentNode(questionsNode, openQuestion, openQuestion.Name);
                    questionNode.ImageIndex = 3;
                    questionNode.SelectedImageIndex = 3;
                }
            }
        }

        private void AddClosedQuestion()
        {
            if (!(Tree.SelectedNode.Tag is Questions)) return;
            Questions questions = Tree.SelectedNode.Tag as Questions;
            ClosedQuestion closedQuestion = (ClosedQuestion)questions.Add(QuestionTypes.Closed);
            ChoiceQuestionForm closedQnFrm = new ChoiceQuestionForm();
            closedQnFrm.PickValues(closedQuestion);
            if (closedQnFrm.ShowDialog() == DialogResult.OK)
            {
                TreeNode questionsNode = Tree.SelectedNode;
                if (questionsNode != null)
                {
                    var questionNode = AddToParentNode(questionsNode, closedQuestion, closedQuestion.Name);
                    questionNode.ImageIndex = 6;
                    questionNode.SelectedImageIndex = 6;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOpenQuestion();
        }

        private void AddEnumList()
        {
            var isEnums = Tree.SelectedNode.Text == "Enum Lists";
            if (!isEnums) return;
            EnumList enumList = _configuration.EnumerationLists.Add();
            EnumListForm form = new EnumListForm();
            form.PickValue(enumList);
            if (form.ShowDialog() == DialogResult.OK)
            {
                TreeNode treeNode = Tree.SelectedNode.Nodes.Add(enumList.Name);
                treeNode.Tag = enumList;
            }
        }

        private void enumListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEnumList();
        }

        private void closedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClosedQuestion();
        }

        private void GenerateDatabase()
        {

            if (_configuration == null)
            {
                MessageBox.Show("There is no configuration");
                return;
            }

            _configuration.Save();
            DbInfoForm frm = new DbInfoForm();
            frm.Execute(_configuration.DbInfo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Load form
                dloDataApplication dloData = new dloDataApplication();
                dloData.Configuration = _configuration;
                dloData.DbInfo.ConnectionString = _configuration.DbInfo.ConnectionString;
                dloData.DbInfo.MasterConnectionString = _configuration.DbInfo.MasterConnectionString;
                dloData.GenerateDatabase(_configuration);
                GenerateDatabaseForm genInfo = new GenerateDatabaseForm();
                genInfo.PickQueries(dloData);
                genInfo.ShowDialog();
            }
        }

        private void ribbonButtonGenerateDatabase_Click(object sender, EventArgs e)
        {
            GenerateDatabase();
        }

        private void subsectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSubSection();
        }

        private void AddMultipleChoiceQuestion()
        {
            if (!(Tree.SelectedNode.Tag is Questions)) return;
            Questions questions = Tree.SelectedNode.Tag as Questions;
            MultipleChoiceQuestion closedQuestion = (MultipleChoiceQuestion)questions.Add(QuestionTypes.MultipleChoice);
            ChoiceQuestionForm closedQnFrm = new ChoiceQuestionForm();
            closedQnFrm.PickValues(closedQuestion);
            if (closedQnFrm.ShowDialog() == DialogResult.OK)
            {
                TreeNode questionsNode = Tree.SelectedNode;
                if (questionsNode != null)
                {
                    var questionNode = AddToParentNode(questionsNode, closedQuestion, closedQuestion.Name);
                    questionNode.ImageIndex = 10;
                    questionNode.SelectedImageIndex = 10;
                }
            }
        }

        private void multipleChoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMultipleChoiceQuestion();
        }

        private void AddMapQuestion()
        {
            if (!(Tree.SelectedNode.Tag is Questions)) return;
            Questions questions = Tree.SelectedNode.Tag as Questions;
            MapQuestion mapQn = (MapQuestion)questions.Add(QuestionTypes.Map);
            MapQuestionForm MapQnFrm = new MapQuestionForm();
            MapQnFrm.PickValues(mapQn);
            if (MapQnFrm.ShowDialog() == DialogResult.OK)
            {
                TreeNode questionsNode = Tree.SelectedNode;
                if (questionsNode != null)
                {
                    var questionNode = AddToParentNode(questionsNode, mapQn, mapQn.Name);
                    questionNode.ImageIndex = 10;
                    questionNode.SelectedImageIndex = 10;
                }
            }
        }

        private void mapQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMapQuestion();
        }

        private void TestUserRights()
        {
            //add userrights
            foreach (var section in _configuration.Questionaires[0].Sections)
            {
                UserRight userright = _configuration.UserRights.Add();
                userright.ObjectName = section.Name;
                userright.IsSystem = true;

                foreach (var subsection in section.SubSections)
                {
                    userright = _configuration.UserRights.Add();
                    userright.ObjectName = subsection.Name;
                    userright.IsSystem = true;
                    foreach (var qn in subsection.Questions)
                    {
                        userright = _configuration.UserRights.Add();
                        userright.ObjectName = qn.Name;
                        userright.IsSystem = true;
                    }
                }

                foreach (var qn in section.Questions)
                {
                    userright = _configuration.UserRights.Add();
                    userright.ObjectName = qn.Name;
                    userright.IsSystem = true;
                }

            }

            //add user
            for (int i = 1; i <= 5; i++)
            {
                User user = _configuration.Users.Add(UserTypes.RokeConsult);
                user.Firstname = "Nana" + 1;
                user.UserName = "Nana" + 1;
                user.Lastname = "Nana" + 1;
                user.Email = "nana@gmail.com";
                user.Usercode = "COO" + i;
                user.Password = i.ToString();
            }

            int x = 0;
            //add userpersmissions
            foreach (var us in _configuration.Users)
            {
                UserPermission userPermission = us.Permissions.Add();
                userPermission.UserRight = _configuration.UserRights[0];
                userPermission.Permission = PermisionType.Add | PermisionType.Edit | PermisionType.Delete;
                x++;
            }
        }

        private void ribbonButtonTest_Click(object sender, EventArgs e)
        {
            TestUserRights();
        }

        private async void UploadConfiguration()
        {
            try
            {
                SaveConfiguration();
                await _configuration.Upload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ribbonButtonUploadConfig_Click(object sender, EventArgs e)
        {
            UploadConfiguration();
        }

        private bool LogIn()
        {
            FrmLogin frm = new FrmLogin();
            return frm.ShowDialog() == DialogResult.OK;
        }

        private void EnableControls(bool enable)
        {
            ribbonButtonNew.Enabled = enable;
            ribbonButtonOpen.Enabled = enable;
            ribbonButtonSave.Enabled = enable;
            ribbonButtonUploadConfig.Enabled = enable;
            ribbonButtonSettings.Enabled = enable;
            ribbonButtonUsers.Enabled = enable;
            ribbonButtonSyncing.Enabled = enable;
            ribbonButtonGenerateDatabase.Enabled = enable;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            EnableControls(false);
            if (LogIn())
            {
                //load application
                Text = "AI Collect Model It - " + DCAnalyticsApp.Instance.CurrentUser.UserName;
                Initialize();
                EnableControls(true);
            }
        }


        private void AddMore()
        {
            EnumList prices = _configuration.EnumerationLists.Add();
            prices.Name = "Prices";

            EnumListValue val = prices.EnumValues.Add();
            val.Code = 2000;
            val.Description = "Coffee";

            val = prices.EnumValues.Add();
            val.Code = 2000;
            val.Description = "Cotton";

            val = prices.EnumValues.Add();
            val.Code = 2000;
            val.Description = "Vanilla";


            //Certifications 
            FairTrade fairTrade = _configuration.Certifications.Add(CertificationTypes.FairTrade) as FairTrade;
            fairTrade.Farmer = new Questionaire(null);
            fairTrade.Name = "fairTrade";
            Section section = fairTrade.Sections.Add();
            section.Name = "Section1";
            SubSection sb2 = section.SubSections.Add();
            sb2.Name = "SubSection1";
            var openQuestion1 = sb2.Questions.AddOpenQuestion();
            openQuestion1.QuestionText = "Where do you stay";
            openQuestion1.Name = "Residence";

            var openQuestion = section.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";


            openQuestion = fairTrade.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";





            //organic
            Organic organic = _configuration.Certifications.Add(CertificationTypes.Organic) as Organic;
            organic.Farmer = new Questionaire(null);
            fairTrade.Name = "fairTrade";
            section = fairTrade.Sections.Add();
            organic.Name = "Section1";
            SubSection sb1 = section.SubSections.Add();
            sb1.Name = "SubSection1";
            openQuestion = sb1.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";

            openQuestion = section.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";

            openQuestion = organic.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";





            //
            UTZ utz = _configuration.Certifications.Add(CertificationTypes.UTZ) as UTZ;
            utz.Farmer = new Questionaire(null);
            utz.Name = "fairTrade";


            section = utz.Sections.Add();
            organic.Name = "Section1";
            SubSection sb = section.SubSections.Add();
            sb.Name = "SubSection1";
            openQuestion = sb.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";

            openQuestion = section.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";


            openQuestion = utz.Questions.AddOpenQuestion();
            openQuestion.QuestionText = "Where do you stay";
            openQuestion.Name = "Residence";




            //Trainings
            Training training = _configuration.Trainings.Add();
            training.Name = "Training1";
            training.StartDate = DateTime.Now;
            training.EndDate = DateTime.Now;


            //trainees
            var tra = training.Trainees.Add();
            tra.Name = "Nana";

            var topic = training.Topics.Add();
            topic.Name = "Topic1";

            var trainer = training.Trainers.Add();
            trainer.Name = "Kato";

            //Purchases
            Purchase purchase = _configuration.Purchases.Add();
            purchase.DateOfPurchase = DateTime.Now;
            purchase.Quantity = 50;
            purchase.Prices = _configuration.EnumerationLists.ByName("Prices");
            purchase.ProductPrice = purchase.Prices.EnumValues.ByDescription("Coffee");
            purchase.Lotid = "Lot90343";
            purchase.Products = _configuration.EnumerationLists.ByName("Products");
            purchase.Product = purchase.Products.EnumValues.ByDescription("Coffee");
            purchase.Farmer = new Questionaire(null);

            Questionaire questionaire = _configuration.Questionaires[0];
            Section section_o = questionaire.Sections[0];
            OpenQuestion question = section_o.Questions.AddOpenQuestion();
            question.QuestionText = "What's your name";
            question.Name = "Name";
            Dependency dependency = question.Dependencies.Add();
            dependency.Target = questionaire.Sections[1];


            //inspection 
            FieldInspection inspection = _configuration.Inspections.Add();
            inspection.FieldName = "Kasese 1";
            var fieldSection = inspection.Sections.Add();
            fieldSection.Name = "Field Section";

            var qn = fieldSection.Questions.Add(QuestionTypes.Open);
            qn.QuestionText = "Whats your name?";

            inspection.Farmer = _configuration.Questionaires[0];

            inspection.Coordinates.Add("Lat:78834;Long:459");


            //adding clients
            _configuration.Client.Contact = "0775407583";
            _configuration.Client.CreatedBy = "Admin";
            _configuration.Client.Email = "charles@gmail.com";
            _configuration.Client.Name = "Kakembo";
            User user = _configuration.Client.Users.Add(UserTypes.ClientUser);
            user.UserName = "Nana";
            user.Password = "Nana";
            user.Email = "Nana@gmail.com";
            user.Firstname = "Nanana";
            user.IsAdmin = true;
            user.Lastname = "Nanana";
            user.Usercode = "N009";
            


        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            AddMore();
        }

    }
}
