using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.ViewModels
{
    
    public class ShellViewModel : Conductor<object>
    {
        
        private LoginViewModel _loginVM;

        public ShellViewModel(LoginViewModel loginVm)
        {
            _loginVM = loginVm;
            ActivateItem(_loginVM);
        }
    }
}
