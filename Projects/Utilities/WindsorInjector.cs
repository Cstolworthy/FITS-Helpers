using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Interfaces.Marker;

namespace Utilities
{
    public class WindsorInjector
    {
        public static void InjectAllInterfaceTypes(IWindsorContainer container,Assembly assembly)
        {
            container.Register(Classes.FromAssembly(assembly).BasedOn<IValueObject>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IAggregateRoot>().WithService.AllInterfaces());
        }
    }
}