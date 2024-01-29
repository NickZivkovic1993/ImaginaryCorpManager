using Caliburn.Micro;
using ICMWPFUserInterface.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.ViewModels
{

    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        //private SimpleContainer _container;
        public ShellViewModel(IEventAggregator events,
                              SalesViewModel salesVM)
        {
            _events = events;
            //subscribe the current instance of the class
            //So it knows whos asking
            _events.Subscribe(this);
            _salesVM = salesVM;
           // _container = container;



            //keep in mind only one one active item at the time learned that the hard way...
            //check Conductor<> def for more info
            //ActivateItem(_container.GetInstance<LoginViewModel>());
            //fixed with transient type instance^^
            //when item is not active loginVM goes away and doesn't have data from previous call

            // Refactor to so i don't need a container from above i'll just coment it as everything else and remove it from constructor
            // Basically learned Caliburn.Micro could do this
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            // new instance of container and rewrite _loginVm
            // so former login was wiped out
            //_loginVM= _container.GetInstance<LoginViewModel>();
            //removed the lot of former loginvm
            //loginVM should not be singleton (it was)
        }
    }
}
