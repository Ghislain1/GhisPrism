﻿namespace GhisPrism.Package
{
    using GhisPrism.Package.Services;
    using GhisPrism.Package.ViewModels;
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
            containerRegistry.RegisterSingleton<ISourcesViewModel, SourcesViewModel>();
            containerRegistry.RegisterSingleton<IGhisSpecialFolderService, GhisSpecialFolderService>();
        }
    }
}