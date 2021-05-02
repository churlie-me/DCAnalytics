using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DCAnalyticsMobile.Models;
using Newtonsoft.Json;

namespace DCAnalyticsMobile.Data
{
    public static class Synchronization
    {
        private static readonly HttpClient _client = new HttpClient();
        internal static async Task<HttpResponseMessage> SignInAsync(string username, string password)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/user/authentication", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(new DCAnalytics.Credentials()
                {
                    Username = username,
                    Password = password
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> ForgotAsync(User user)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/user/password/forgot/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(user);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> VerifyUser(User user)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/user/verify/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(user);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> ResetPassword(User user)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/user/password/reset/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(user);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> Configurations(User user)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/Configuration/Client/Mobile/{0}", user.ClientId));

            try
            {
                var response = await _client.GetAsync(uri);
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> SynchronizeQuestionaire(Questionaire questionaire)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/sync/questionaire/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(questionaire);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> SynchronizeInspection(FieldInspection inspection)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/sync/inspection/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(inspection);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> SynchronizeCertification(Certification certification)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/sync/certification/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(certification);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
        
        internal static async Task<HttpResponseMessage> SynchronizePurchase(Purchase purchase)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/sync/purchase/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(purchase);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> SynchronizeTraining(Training training)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/sync/training/", string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(training);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> Client(string clientId)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/Clients/{0}",  clientId));

            try
            {
                var response = await _client.GetAsync(uri);
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        internal static async Task<HttpResponseMessage> GetModifiedQuestionaire(int oid)
        {
            var uri = new Uri(string.Format(Constants.EndPoint + "/questionaire/{0}", oid));
            try
            {
                var response = await _client.GetAsync(uri);

                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
