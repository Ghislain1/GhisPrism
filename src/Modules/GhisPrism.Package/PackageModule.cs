namespace GhisPrism.Package
{
    using Core;
    using Core.Commons;
    using GhisPrism.Package.Services;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using Unity;
    using Views;

    public class PackageModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.PackageListViewRegion, typeof(PackageListView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IChocolateyService, ChocolateyService>();
        }
    }
}