namespace GhisPrism.FileExplorerRibbon
{
  using Core.Commons;
  using Prism.Modularity;
  using Prism.Regions;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using Views;

  public class RibbonModule : IModule
  {
    private IRegionManager regionManager;

    public RibbonModule(IRegionManager regionManager)
    {
      this.regionManager = regionManager;
    }

    public void Initialize()
    {
      regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(RibbonView));
    }
  }
}