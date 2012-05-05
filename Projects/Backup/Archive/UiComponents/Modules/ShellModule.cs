using System;
using InterfacesAndDTO.Interfaces.Modules;
using InterfacesAndDTO.Interfaces.Repositories;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Repositories;
using UiComponents.Views;

namespace UiComponents.Modules
{
    public class ShellModule : IShellModule
    {
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer Container { get; set; }

        public ShellModule(IUnityContainer container, IRegionManager manager)
        {
            Container = container;
            RegionManager = manager;
        }

        public void Initialize()
        {
            this.Container.RegisterType<IFitsImageRepository, FitsImageRepository>(new ContainerControlledLifetimeManager());

            // Show the Orders Editor view in the shell's main region.
            RegionManager.RegisterViewWithRegion("MainMenuRegion",
                                                       () => Container.Resolve<MainMenuView>());
//
            // Show the Orders Toolbar view in the shell's toolbar region.
//            this.regionManager.RegisterViewWithRegion("GlobalCommandsRegion",
//                                                       () => this.container.Resolve<OrdersToolBar>());
        }
    }
}
