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
    public partial class Certificates : PopupPage
    {
        private ConfigurationPageState configurationPageState;
        private Configuration configuration;
        private Questionaire questionaire;
        private List<Certification> certs;
        private User User = AiDataStore.GetUser();
        public Certificates(Configuration configuration, Questionaire questionaire, ConfigurationPageState configurationPageState)
        {
            InitializeComponent();
            this.configurationPageState = configurationPageState;
            this.configuration = configuration;
            this.questionaire = questionaire;
            if(configuration != null)
                Init();
        }

        private void Init()
        {
            try
            {
                var ans = questionaire.Sections.FirstOrDefault().Questions.Find(x => x.QuestionText == "Name").Answers.FirstOrDefault();
                name.Text = ans.AnswerText;

                certs = configuration.Certifications.Where(x => x.Status == DCAnalytics.Statuses.Template).ToList();
                certs.ForEach(delegate (Certification c)
                {
                    var cert = configuration.Certifications.Find(x => x.FarmerKey == questionaire.Key && x.Name == c.Name);
                    if (cert != null)
                        c.Sequence = 0;
                    else
                        c.Sequence = 1;
                });

                if (configuration.Certifications.Count > 0)
                    certifications.ItemsSource = certs;
                else
                {
                    nocertifications.IsVisible = true;
                    certifications.IsVisible = false;
                }
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
                certifications.ItemsSource = certs;
            }
            else
            {
                certifications.ItemsSource = certs.Where(s => s.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        private Certification cert;
        private void OnCertificationTapped(object sender, ItemTappedEventArgs args)
        {
            try
            {
                var certification = args.Item as Certification;
                if (certification.Sequence == 0)
                    cert = configuration.Certifications.Find(x => x.Name == certification.Name && x.FarmerKey == questionaire.Key);
                else
                {
                    cert = new Certification
                    {
                        Template = certification.Key,
                        Name = certification.Name,
                        CreatedBy = User.Key,
                        Sections = certification.Sections,
                        CerificationType = certification.CerificationType,
                        Description = certification.Description,
                        ConfigurationId = configuration.OID
                    };
                    cert.Sections.SelectMany(s => s.Questions).ForEach(q => q.Answers.Clear());
                }
                configurationPageState.OnCertificationSelected(cert);
            }
            catch(Exception ex)
            {

            }
        }

        private async void ExitCertificates(object sender, EventArgs args)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
        }
    }
}