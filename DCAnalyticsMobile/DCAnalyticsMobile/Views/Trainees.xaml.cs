using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trainees : ContentPage
	{
        private QuestionairePageState questionairePageState;
        private Configuration configuration;
        private List<Questionaire> qns;
        private Models.Training training;
        private List<QItem> qItems = new List<QItem>();
        public Trainees (Configuration configuration, Models.Training training, QuestionairePageState questionairePageState)
		{
			InitializeComponent ();
            this.questionairePageState = questionairePageState;
            this.configuration = configuration;
            this.training = training;
            if (configuration != null)
                Init();
        }

        private void Init()
        {
            try
            {
                qns = configuration.Questionaires.Where(x => x.Status == DCAnalytics.Statuses.Partial || x.Status == DCAnalytics.Statuses.Completed).ToList();
                foreach (Questionaire questionaire in qns)
                    qItems.Add(new QItem
                    {
                        ID = questionaire.Key,
                        Name = questionaire.Sections.FirstOrDefault().Questions.Find(x => x.QuestionText == "Name").Answers.FirstOrDefault().AnswerText,
                        Sequence = (qns.IndexOf(questionaire) % 2 == 0) ? 0 : 1
                    });

                if (qItems.Count == 0)
                {
                    notrainees.IsVisible = true;
                    trainees.IsVisible = false;
                }
                else
                {
                    notrainees.IsVisible = false;
                    trainees.IsVisible = true;
                    trainees.ItemsSource = null;
                    trainees.ItemsSource = qItems;
                }
            }
            catch(Exception)
            {

            }
        }

        private void OnTraineeTapped(object sender, ItemTappedEventArgs args)
        {
            try
            {
                var qItem = args.Item as QItem;
                var qn = qns.Find(q => q.Key == qItem.ID);
                qn.IsSelected = true;

                var _training = configuration.Trainings.Find(x => x.Name == training.Name);

                var _trainee = _training.Trainees.Find(t => t.FarmerKey == qn.Key);
                if (_trainee == null)
                {
                    _trainee = new Trainee
                    {
                        Key = Guid.NewGuid().ToString(),
                        FarmerKey = qn.Key
                    };

                    _training.Trainees.Add(_trainee);
                }
                
                AiDataStore.SaveConfiguration(configuration);

                Navigation.RemovePage(this);
            }
            catch (Exception ex)
            {

            }
        }

        private void SearchTrainee(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                trainees.ItemsSource = qns;
            }
            else
            {
                trainees.ItemsSource = qns.Where(s => s.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}