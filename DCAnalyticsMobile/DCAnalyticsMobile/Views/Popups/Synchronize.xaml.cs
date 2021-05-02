using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Data;
using Newtonsoft.Json;
using Device = Xamarin.Forms.Device;
using DCAnalyticsMobile.Models;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Synchronize : PopupPage
    {
        private PromptPageState promptPageState;
        private Configuration configuration;
        public bool Sync = false;
        public Synchronize(PromptPageState promptPageState)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
        }

        private void OnCancel(object sender, EventArgs args)
        {
            Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
        }

        private void OnSynchronize(object sender, EventArgs args)
        {
            Sync = true;
            Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
            promptPageState.OnRebound();
        }
    }
}