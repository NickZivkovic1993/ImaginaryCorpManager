using Caliburn.Micro;
//using ICMWPFUserInterface.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICMWPFUserInterface.Library.Api;
using ICMWPFUserInterface.EventModels;

namespace ICMWPFUserInterface.ViewModels
{
    //Screen from Caliburn.Micro
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IAPIHelper _apiHelper;
        private readonly IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value; 
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }


        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

       
        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length>0)
                {
                    output = true;
                }
                return output; 
            }
            
        }

        private string _errorMessage;

        
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                // CAREFUL ABOUT THE ORDER YOU MORON!!!
                _errorMessage = value; 
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() =>ErrorMessage);
            }
        }



        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                //capture more info about user
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);

                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                //publish a class instance for an empty class
                //just to differentiate it from different events
                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage= ex.Message;
            }
        }
    }
}

        //Caliburn Possible Bug
        //Add ? (not null) after variables and !seems to work
        //also changed from a method to a ctor
        // did stackoverflow answer 

        //TODO: Redo xaml to get passwordbox to work
