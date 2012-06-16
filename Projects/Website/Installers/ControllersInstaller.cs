using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Interfaces.Marker;
using Utilities;

namespace Website.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                   .BasedOn<IController>()
                                   .LifestyleTransient());

            Injector.InjectAllInterfaceTypes(container,typeof(ControllersInstaller).Assembly);
            
         
        }
    }
}