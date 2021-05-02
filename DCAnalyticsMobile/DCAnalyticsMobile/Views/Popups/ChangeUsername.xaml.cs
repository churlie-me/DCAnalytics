using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeUsername : PopupPage
    {
        private PromptPageState promptPageState;
        private Configuration configuration;
        private User user;
        public ChangeUsername(PromptPageState promptPageState)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
            this.configuration = AiDataStore.GetConfiguration();
            this.user = AiDataStore.GetUser();

            Username.Text = user.UserName;
        }

        private void OnCancel(object sender, EventArgs args)
        {
            Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
        }

        private void OnSave(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(Username.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Enter username to proceed", MessageType.Regular, promptPageState), true));
                    return;
                }

                if (user.UserName.Equals(Username.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("The username you've entered is the same as the current one", MessageType.Regular, promptPageState), true));
                    return;
                }

                //Save configuration
                configuration.Users.Find(x => x.UserName == user.UserName).UserName = Username.Text;
                AiDataStore.SaveConfiguration(configuration);

                //Save user
                user.UserName = Username.Text;
                AiDataStore.SaveUser(user);

                //Close Popup
                promptPageState.OnResumePage(null);
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Regular, promptPageState), true));
            }
        }
    }
}