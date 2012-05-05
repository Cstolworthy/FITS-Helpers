using Microsoft.Practices.Unity;

namespace AstronomySite
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
}
