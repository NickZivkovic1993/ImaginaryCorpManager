using Caliburn.Micro;
using ICMWPFUserInterface.Helpers;
using ICMWPFUserInterface.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ICMWPFUserInterface
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();


            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }



        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>();

            //Reflexion (i'm fine with taking performance hit here) since its only a few
            //ViewModels that are going to get used
            //       --- Register new instance of UI class every time you use it ----

            GetType().Assembly.GetTypes() // get every type that exist in the app
                .Where(type => type.IsClass) // limit to only class types (to get)
                .Where(type => type.Name.EndsWith("ViewModel"))// limit further to types that end in selected string
                .ToList() // put all types within that limit into a list so i can work with foreach
                .ForEach(viewModelType => _container.RegisterPerRequest( // Register per request the ViewModel
                    viewModelType, viewModelType.ToString(), viewModelType)); // RegisterPerRequest parameters
            //hopefully i'll change this
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        // initialization of a wpf password wireup problem ,
        // seems to work right now with just a not null operand (?)

        //public Bootstrapper()
        //{
        //    Initialize();

        //    ConventionManager.AddElementConvention<PasswordBox>(
        //        PasswordBoxHelper.BoundPasswordProperty,
        //        "Password",
        //        "PasswordChanged");
        //}
    }


}
