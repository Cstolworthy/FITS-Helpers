using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Interfaces.Marker;

namespace Utilities
{
    public class Injector
    {
        public static void InjectAllInterfaceTypes(IWindsorContainer container, Assembly assembly)
        {
            container.Register(Classes.FromAssembly(assembly).BasedOn<IDataAccess>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IManager>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IService>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IMapper>().WithService.AllInterfaces());
        }
    }
}