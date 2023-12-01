using ICMWPFUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ICMWPFUserInterface.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient { get; set; }

        public APIHelper()
        {
            InitializeClient();
        }
        private void InitializeClient()
        {
            //load api from appsettings from url to here
            //config file override to be added in App.config
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        //call a token and get a response
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            //url is going to change
            //local , server , azure
            using (HttpResponseMessage response = await apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    //successful auth get here
                    //var result = await response.Content.ReadAsStringAsync();
                    //trying to figure out difference between those two
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    // Pronounced reason frejz
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
    }
}
