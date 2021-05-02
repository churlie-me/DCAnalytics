using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage, PromptPageState
	{
		public Settings ()
		{
			InitializeComponent ();
            (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void OnRebound()
        {
            throw new NotImplementedException();
        }

        public void OnResumePage(object o)
        {
            try
            { 
                if((FileData)o != null)
                    ExtensionMethods.DeserializeConfiguration((FileData)o, this);
            }
            catch(Exception ex)
            {

            }
        }

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        public void OnSleepPage()
        {
            throw new NotImplementedException();
        }

        private void ChangeConfiguration(object sender, EventArgs e)
        {
            try
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new SelectConfiguration(this), true));
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}