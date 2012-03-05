using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace InterfacesAndDTO.Interfaces.Modules
{
    public interface IShellModule : IModule
    {
        IRegionManager RegionManager { get; set; }
        IUnityContainer Container { get; set; }
    }
}
