﻿using ICMWPFUserInterface.Library.Api;
using ICMWPFUserInterface.Library.Models;
using ICMWPFUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ICMWPFUserInterface.Library.Api
{
    public class APIHelper : IAPIHelper 
    {
        private ILoggedInUserModel _loggedInUser;
        private HttpClient _apiClient;

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitializeClient();
            _loggedInUser = loggedInUser;
        }
        public HttpClient ApiClient 
        { 
            get 
            { 
                return _apiClient; 
            } 
        }
        private void InitializeClient()
        {
            //load api from appsettings from url to here
            //config file override to be added in App.config
            string api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            using (HttpResponseMessage response = await _apiClient.PostAsync("/Token", data))
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
        public async Task GetLoggedInUserInfo(string token) 
        {
            //always add clear httpclient just to be sure
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (HttpResponseMessage response = await _apiClient.GetAsync("/api/User"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUser.CreatedDate = result.CreatedDate;
                    _loggedInUser.EmailAddresse = result.EmailAddresse;
                    _loggedInUser.Id = result.Id;
                    _loggedInUser.FirstName=result.FirstName;
                    _loggedInUser.LastName=result.LastName;
                    _loggedInUser.Token = token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
    }
}
