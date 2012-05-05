using Microsoft.Practices.Unity;

namespace Interfaces
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
}
