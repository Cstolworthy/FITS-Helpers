using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Utilities;

namespace Repositories
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            WindsorInjector.InjectAllInterfaceTypes(container, typeof(Installer).Assembly);
        }
    }
}