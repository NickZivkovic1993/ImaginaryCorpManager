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

        //Caliburn Possible Bug
        //Add ? (not null) after variables and seems to work
        //also changed from a method to a ctor


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
                var result = await _apiHelper.Authenticate(UserName, Password);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
