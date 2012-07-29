using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Utilities;

namespace Core
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            MongoClassMapper.Map();
            WindsorInjector.InjectAllInterfaceTypes(container, typeof(Installer).Assembly);
        }
    }
}