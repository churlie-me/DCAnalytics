using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Purchase : ContentPage, SelectPageState, PromptPageState
    {
        private Questionaire questionaire;
        private Configuration configuration;
        private AIDropdown aIDropdown;
        Models.Purchase purchase;
        private User User = AiDataStore.GetUser();
        public Purchase(Models.Purchase purchase = null, Questionaire questionaire = null)
        {
            InitializeComponent();
            configuration = AiDataStore.GetConfiguration();
            this.questionaire = questionaire;
            this.purchase = purchase;

            Question qn = questionaire.Sections.FirstOrDefault().Questions.Find(x => x.QuestionText == "Name");
            if (qn != null)
                name.Text = qn.Answers.FirstOrDefault().AnswerText;

            if (purchase != null)
                Init();
        }

        private void Init()
        {
            var station = configuration.Regions.EnumValues.Find(r => r.Code == purchase.Station);
            if (station != null)
            {
                stationLbl.Text = station.Description;
                stationLbl.ClassId = station.Code.ToString();
            }

            var product = configuration.Products.EnumValues.Find(r => r.Code == purchase.Product);
            if(product != null)
            {
                productLbl.Text = product.Description;
                productLbl.ClassId = product.Code.ToString();
            }
            price.Text = purchase.Price.ToString();
            qty.Text = purchase.Quantity.ToString();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void OnRebound()
        {
            throw new NotImplementedException();
        }

        public void OnResumePage(bool o)
        {
            throw new NotImplementedException();
        }

        public void OnSleepPage()
        {
            throw new NotImplementedException();
        }

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        private void PurchaseItem(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(stationLbl.ClassId) || string.IsNullOrEmpty(productLbl.ClassId) || string.IsNullOrEmpty(qty.Text) || string.IsNullOrEmpty(price.Text))
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("All fields should be filled", MessageType.Regular, this), true));
                else
                {
                    if (purchase == null)
                        purchase = new Models.Purchase
                        {
                            Key = Guid.NewGuid().ToString(),
                            Lotid = (configuration.Purchases.Count() == 0) ? "LotId1" : "LotId" + (Convert.ToInt64(Regex.Match(configuration.Purchases.Last().Lotid, @"\d+$").Value) + 1),
                            DateOfPurchase = DateTime.Now.Date,
                            Farmer = questionaire.Key,
                            ConfigurationId = configuration.OID,
                            CreatedBy = User.Key
                        };

                    purchase.Price = Convert.ToDecimal(price.Text);
                    purchase.Quantity = Convert.ToDecimal(qty.Text);
                    purchase.Product = int.Parse(productLbl.ClassId);
                    purchase.Station = int.Parse(stationLbl.ClassId);
                    purchase.TotalAmount = Convert.ToDecimal(price.Text) * Convert.ToDecimal(qty.Text);

                    var configPurchase = configuration.Purchases.Find(x => x.Key == purchase.Key);
                    if (configPurchase == null)
                        configuration.Purchases.Add(purchase);
                    else
                        configPurchase = purchase;

                    AiDataStore.SaveConfiguration(configuration);

                    Navigation.RemovePage(this);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void SelectStation(object sender, EventArgs args)
        {
            aIDropdown = new AIDropdown(configuration.Regions.EnumValues, this, stationLbl);
            await PopupNavigation.Instance.PushAsync(aIDropdown, true);
        }


        private async void SelectProduct(object sender, EventArgs args)
        {
            aIDropdown = new AIDropdown(configuration.Products.EnumValues, this, productLbl);
            await PopupNavigation.Instance.PushAsync(aIDropdown, true);
        }

        private void AllotPrice()
        {
            if (!string.IsNullOrEmpty(productLbl.ClassId))
            {
                EnumValue v = configuration.Prices.EnumValues.Find(x => x.Code == Convert.ToInt32(productLbl.ClassId));
                if (v != null)
                    price.Text = v.Description;
            }
        }

        public void OnResumePage(object o)
        {
            throw new NotImplementedException();
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
                total.Text = (Convert.ToDecimal(e.NewTextValue) * Convert.ToDecimal(qty.Text)).ToString();
        }

        private void Qty_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
                total.Text = (Convert.ToDecimal(e.NewTextValue) * Convert.ToDecimal(price.Text)).ToString();
        }

        public async void OnDropDownOptionSelected()
        {
            await PopupNavigation.Instance.RemovePageAsync(aIDropdown);
            AllotPrice();
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}