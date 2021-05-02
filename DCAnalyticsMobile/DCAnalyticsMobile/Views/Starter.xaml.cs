using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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
    public partial class Starter : ContentPage, SelectPageState, PromptPageState
    {
        private Questionaire Questionaire;
        private QuestionairePageState questionairePageState;
        private Configuration configuration = AiDataStore.GetConfiguration();
        private AIDropdown aIDropdown;
        public Starter(Questionaire Questionaire, SelectPageState selectPageState = null, QuestionairePageState questionairePageState = null)
        {
            InitializeComponent();
            this.Questionaire = Questionaire;
            this.questionairePageState = questionairePageState;
        }

        protected override void OnAppearing()
        {
            
            try
            {
                if (Questionaire.Regions.Count > 0)
                {
                    _region.IsVisible = true;
                    if (Questionaire.Region != null)
                    {
                        var region = Questionaire.Regions.Find(x => x.Key == Questionaire.Region.Key);
                        if (region != null)
                        {
                            regionSelected.Text = region.Name;
                            regionSelected.ClassId = region.Key;
                        }
                    }
                }

                if (Questionaire.Categories.Count > 0)
                {
                    _category.IsVisible = true;

                    if (Questionaire.Category != null)
                    {
                        var category = Questionaire.Categories.Find(x => x.Key == Questionaire.Category.Key);
                        if (category != null)
                        {
                            categorySelected.Text = category.Name;
                            categorySelected.ClassId = category.Key;
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public async void OnSelectRegion(object sender, EventArgs args)
        {
            try
            {
                aIDropdown = new AIDropdown(null, this, regionSelected, null,  Questionaire.Regions);
                await PopupNavigation.Instance.PushAsync(aIDropdown, true);
            }
            catch(Exception ex)
            {

            }
        }

        public async void OnSelectCategory(object sender, EventArgs args)
        {
            try
            {
                aIDropdown = new AIDropdown(null, this, categorySelected, Questionaire.Categories, null);
                await PopupNavigation.Instance.PushAsync(aIDropdown, true);
            }
            catch (Exception ex)
            {

            }
        }

        public async void Next(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new QSections(DCAnalytics.ObjectType.None, Questionaire, questionairePageState));
                Navigation.RemovePage(this);
            }
            catch(Exception ex)
            {

            }
        }

        private void OnRemove(object sender, EventArgs args)
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (!string.IsNullOrEmpty(Questionaire.Key))
                        await PopupNavigation.Instance.PushAsync(new MessageBox("Are you sure you would like to delete this questionaire?", MessageType.Warning, this));
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        public void OnConfirm()
        {
            try
            {
                configuration.Questionaires.Remove(configuration.Questionaires.Find(x => x.Key == Questionaire.Key));
                AiDataStore.SaveConfiguration(configuration);
                Navigation.RemovePage(this);
            }
            catch (Exception ex)
            {

            }
        }

        public async void OnDropDownOptionSelected()
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(aIDropdown);

                if (!string.IsNullOrEmpty(categorySelected.Text))
                    Questionaire.Category = Questionaire.Categories.Find(r => r.Key == categorySelected.ClassId);

                if (!string.IsNullOrEmpty(regionSelected.Text))
                    Questionaire.Region = Questionaire.Regions.Find(r => r.Key == regionSelected.ClassId);
            }
            catch(Exception ex)
            {

            }
        }

        public void OnResumePage(bool o)
        {
            throw new NotImplementedException();
        }

        public void OnSleepPage()
        {
            throw new NotImplementedException();
        }

        public void OnRebound()
        {
            throw new NotImplementedException();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void OnResumePage(object o)
        {
            throw new NotImplementedException();
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}