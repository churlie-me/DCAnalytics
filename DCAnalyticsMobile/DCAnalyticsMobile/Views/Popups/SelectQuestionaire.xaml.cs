using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectQuestionaire : PopupPage
    {
        private QuestionairePageState questionairePageState;
        private Configuration configuration;
        private Questionaire questionaire;
        private List<Questionaire> qns;
        public SelectQuestionaire(Configuration configuration, QuestionairePageState questionairePageState)
        {
            InitializeComponent();
            this.questionairePageState = questionairePageState;
            this.configuration = configuration;
            if(configuration != null)
                Init();
        }

        private void Init()
        {
            try
            {
                qns = configuration.Questionaires.Where(x => x.Status == DCAnalytics.Statuses.Template).ToList();
                questionaires.ItemsSource = qns;
            }
            catch (Exception ex)
            {

            }
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                questionaires.ItemsSource = qns;
            }
            else
            {
                questionaires.ItemsSource = qns.Where(s => s.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        private void OnQuestionaireTapped(object sender, ItemTappedEventArgs args)
        {
            try
            {
                var selectedQn = args.Item as Questionaire;
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
                questionairePageState.OnQuestionaireSelected(selectedQn);
            }
            catch(Exception ex)
            {

            }
        }
    }
}