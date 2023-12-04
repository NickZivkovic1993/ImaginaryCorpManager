using Caliburn.Micro;
using ICMWPFUserInterface.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.ViewModels
{
    //Screen from Caliburn.Micro
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password = "";

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
        private IAPIHelper _apiHelper;
        public LoginViewModel(IAPIHelper ApiHelper)
        {
            _apiHelper = ApiHelper;
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



        //Caliburn Possible Bug
        //Add ? (not null) after variables and seems to work
        //also changed from a method to a ctor
        // did stackoverflow answer 

        //TODO: Redo xaml to get passwordbox to work

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
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);
            }
            catch (Exception ex)
            {
                ErrorMessage= ex.Message;
            }
        }
    }
}
