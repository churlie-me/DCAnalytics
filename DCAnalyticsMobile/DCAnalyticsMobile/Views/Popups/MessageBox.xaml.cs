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
    public partial class MessageBox : PopupPage
    {
        private PromptPageState promptPageState;
        private LocationPageState locationPageState;
        private MessageType type;
        public MessageBox(string message, MessageType type, PromptPageState promptPageState, LocationPageState locationPageState = null)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
            this.locationPageState = locationPageState;
            this.type = type;
            msg.Text = message;
        }

        protected override void OnAppearing()
        {
            Init();
        }

        private void Init()
        {
            try
            {
                if (type == MessageType.Gps)
                    proceedBtn.Text = "Enable";
                else if (type == MessageType.Regular)
                    proceedBtn.Text = "Ok";
                else if (type == MessageType.Exit)
                    proceedBtn.Text = "Exit";
                else if (type == MessageType.Info)
                {
                    msgTitle.Text = "Status";
                    proceedBtn.Text = "Ok";
                }
                else if (type == MessageType.Warning)
                {
                    msgTitle.Text = "Warning!!!";
                    proceedBtn.Text = "Confirm";
                }
                else if (type == MessageType.Discard)
                {
                    msgTitle.Text = "Are you sure want to leave this form?";
                    cancelBtn.Text = "Discard";
                    proceedBtn.Text = "Save Draft";
                }
                else if(type == MessageType.Logout)
                {
                    msgTitle.Text = "Status";
                    proceedBtn.Text = "Logout";
                }
            }
            catch(Exception ex)
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

        private void OnProceed(object sender, EventArgs args)
        {
            try
            {
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));

                switch (type)
                {
                    case MessageType.Configuration:
                        promptPageState.OnRebound();
                        break;
                    case MessageType.Exit:
                    case MessageType.Logout:
                        promptPageState.OnExit();
                        break;
                    case MessageType.Gps:
                        locationPageState.OnEnableLocation();
                        break;
                    case MessageType.Regular:
                        promptPageState.OnResumePage(null);
                        break;
                    case MessageType.Warning:
                        promptPageState.OnConfirm();
                        break;
                    case MessageType.Discard:
                        promptPageState.OnSaveDraft();
                        break;
                }
            }
            catch (Exception ex)
            {
                //DisplayAlert("Error", ex.Message);
                Debug.WriteLine($"Exception after Selection Complete:  {ex}");
            }
        }

        private void OnCancel(object sender, EventArgs args)
        {
            try
            {
                switch (type)
                {
                    case MessageType.Discard:
                        promptPageState.OnExit();
                        break;
                    default:
                        if (type.Equals(MessageType.Gps))
                            locationPageState.OnLocationIgnored();
                        break;
                }

                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
            }
            catch (Exception ex)
            {
                //DisplayAlert("Error", ex.Message);
                Debug.WriteLine($"Exception after Selection Complete:  {ex}");
            }
        }
    }
}