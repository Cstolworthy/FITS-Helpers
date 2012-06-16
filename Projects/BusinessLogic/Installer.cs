using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Utilities;

namespace BusinessLogic
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Injector.InjectAllInterfaceTypes(container,typeof(Installer).Assembly);
        }
    }
}
