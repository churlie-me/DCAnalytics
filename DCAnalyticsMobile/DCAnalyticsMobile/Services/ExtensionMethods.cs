using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Views;
using DCAnalyticsMobile.Views.Popups;
using Newtonsoft.Json;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace DCAnalyticsMobile.Services
{
    public class ExtensionMethods
    {
        public static void DeserializeConfiguration(FileData fileData, PromptPageState promptPageState)
        {
            try
            {
                string json = System.IO.File.ReadAllText(fileData.FilePath).Replace("\r\n", string.Empty).Replace("\t", string.Empty).Replace("  ", String.Empty); ;
                json = Regex.Unescape(json).Replace(@"\s+", "");
                var configuration = JsonConvert.DeserializeObject<Configuration>(json);
                if (configuration != null)
                {
                    AiDataStore.SaveConfiguration(configuration);
                    App.Current.MainPage = new SignIn();
                }
            }
            catch (Exception ex)
            {
                Log.Warning("Configuration Deserialization Exception", ex.StackTrace);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Your configuration has an issue, please load another one to proceed", MessageType.Configuration, promptPageState)));
            }
        }
    }
}
