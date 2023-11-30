using Caliburn.Micro;
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

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value; 
                NotifyOfPropertyChange(() => UserName);
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }
       
        //Caliburn Possible Bug

        //public bool CanLogIn(string userName, string password)
        //{
        //    
        //}

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

        public void LogIn(string userName, string password)
        {
            Console.WriteLine();
        }
    }
}
