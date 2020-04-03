namespace GhisPrism.FileExplorerRibbon
{
    using Core.Commons;
    using Prism.Ioc;
    using Prism.Modularity;
    using Views;

    public class RibbonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation(typeof(RibbonView), RegionNames.RibbonRegion);
        }
    }
}