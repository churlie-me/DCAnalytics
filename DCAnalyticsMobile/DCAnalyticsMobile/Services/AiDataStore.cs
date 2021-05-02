using DCAnalyticsMobile.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using static Xamarin.Forms.Application;
using System.Collections.Generic;

namespace DCAnalyticsMobile.Services
{
    public static class AiDataStore
    {
        public static void SaveUser(User _user)
        {
            var json = JsonConvert.SerializeObject(_user);
            if (Current.Properties.ContainsKey("user"))
                Current.Properties.Remove("user");

            Current.Properties.Add("user", json);
            Current.SavePropertiesAsync();
        }

        public static void SaveConfiguration(Configuration configuration)
        {
            var json = JsonConvert.SerializeObject(configuration);
            if (Current.Properties.ContainsKey("configuration"))
                Current.Properties.Remove("configuration");

            Current.Properties.Add("configuration", json);
            Current.SavePropertiesAsync();
        }

        /// <summary>
        ///     Method responsible for Getting a full User JSON object.
        /// </summary>
        /// <returns>user object</returns>
        public static User GetUser()
        {
            var userJson = "";
            if (Current.Properties.ContainsKey("user")) userJson = Current.Properties["user"] as string;

            // deserialize the json into the object
            var settings = new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.IsoDateFormat };
            var _user = JsonConvert.DeserializeObject<User>(userJson, settings);

            return _user;
        }

        /// <summary>
        ///     Method responsible for Getting a full User JSON object.
        /// </summary>
        /// <returns>user object</returns>
        public static Configuration GetConfiguration()
        {
            var json = "";
            if (Current.Properties.ContainsKey("configuration")) json = Current.Properties["configuration"] as string;

            // deserialize the json into the object
            var settings = new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.IsoDateFormat };
            Configuration configuration = JsonConvert.DeserializeObject<Configuration>(json, settings);

            return configuration;
        }

        public static List<Configuration> Configurations()
        {
            var json = "";
            if (Current.Properties.ContainsKey("configurations")) json = Current.Properties["configurations"] as string;

            // deserialize the json into the object
            var settings = new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.IsoDateFormat };
            List<Configuration> configurations = JsonConvert.DeserializeObject<List<Configuration>>(json, settings);

            return configurations;
        }

        internal static void SaveConfigurations(List<Configuration> configurations)
        {
            try
            {
                var json = JsonConvert.SerializeObject(configurations);
                if (Current.Properties.ContainsKey("configurations"))
                    Current.Properties.Remove("configurations");

                Current.Properties.Add("configurations", json);
                Current.SavePropertiesAsync();
            }
            catch(Exception ex)
            {

            }
        }

        internal static void SaveClient(Client client)
        {
            try
            {
                var json = JsonConvert.SerializeObject(client);
                if (Current.Properties.ContainsKey("client"))
                    Current.Properties.Remove("client");

                Current.Properties.Add("client", json);
                Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public static Client Client()
        {
            var json = "";
            if (Current.Properties.ContainsKey("client")) 
                json = Current.Properties["client"] as string;

            // deserialize the json into the object
            var settings = new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.IsoDateFormat };
            var client = JsonConvert.DeserializeObject<Client>(json, settings);

            return client;
        }

        /// <summary>
        ///     Method Responsible for Logging out.
        /// </summary>
        public static async void Logout()
        {
            if (Current.Properties.ContainsKey("user"))
            {
                Current.Properties.Remove("user");
                Current.Properties.Clear();
                await Current.SavePropertiesAsync();
            }
        }
    }
}
