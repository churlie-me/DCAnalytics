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
    public partial class ChangePassword : PopupPage
    {
        private PromptPageState promptPageState;
        private Configuration configuration;
        private User user;
        public ChangePassword(PromptPageState promptPageState)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
            configuration = AiDataStore.GetConfiguration();
            user = AiDataStore.GetUser();
        }

        private void OnCancel(object sender, EventArgs args)
        {
            Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
        }

        private void OnSave(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(CPassword.Text) || string.IsNullOrEmpty(NPassword.Text) || string.IsNullOrEmpty(Password.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Enter missing password to proceed", MessageType.Regular, promptPageState), true));
                    return;
                }

                if (user.Password.Equals(NPassword.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("You've entered a wrong current password", MessageType.Regular, promptPageState), true));
                    return;
                }

                if (!NPassword.Text.Equals(Password.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("New Password doesnot match the confirmed password", MessageType.Regular, promptPageState), true));
                    return;
                }

                //Save configuration
                configuration.Users.Find(x => x.UserName == user.UserName).Password = NPassword.Text;
                AiDataStore.SaveConfiguration(configuration);

                //Save user
                user.Password = NPassword.Text;
                AiDataStore.SaveUser(user);

                //Close Popup
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Regular, promptPageState), true));
            }
        }
    }
}