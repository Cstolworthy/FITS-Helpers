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
            
            container.Register(Classes.FromAssembly(assembly).BasedOn<IAggregateRoot>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IContext>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IEntity>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IFactory>());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IMapper>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IPolicy>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IRepository>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IService>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IState>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IValidationRule>().WithService.AllInterfaces());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IValueObject>().WithService.AllInterfaces());
            
        }
    }
}