namespace GhisPrism.Package
{
    using Core;
    using Core.Commons;
    using Core.Models;
    using GhisPrism.Package.Services;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;
    using ViewModels;
    using Views;

    public class PackageModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public PackageModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            // this.container.RegisterType<IFileItemViewModel, FileItemViewModel>(new
            // InjectionConstructor(typeof(string), typeof(FileItemType), typeof(IFileItemService)));
        }

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