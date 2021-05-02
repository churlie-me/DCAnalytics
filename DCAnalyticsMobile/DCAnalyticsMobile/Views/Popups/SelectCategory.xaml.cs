using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCategory : PopupPage
    {
        private QuestionairePageState questionairePageState;
        private Questionaire Questionaire;
        public SelectCategory(Questionaire Questionaire, QuestionairePageState questionairePageState)
        {
            InitializeComponent();
            this.questionairePageState = questionairePageState;
            this.Questionaire = Questionaire;
            Init();
        }

        private void Init()
        {
            categories.ItemsSource = Questionaire.Categories;
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
                categories.ItemsSource = Questionaire.Categories;
            }
            else
            {
                categories.ItemsSource = Questionaire.Categories.Where(s => s.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        private void OnCategorySelected(object sender, ItemTappedEventArgs args)
        {
            try
            {
                var category = args.Item as Category;
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
                this.Questionaire.Category = category;
                questionairePageState.OnCategorySelectedAsync(category);
            }
            catch (Exception ex)
            {

            }
        }
    }
}