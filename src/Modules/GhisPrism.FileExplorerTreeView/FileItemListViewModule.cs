namespace GhisPrism.FileExplorerTreeView
{
  using Core;
  using Core.Commons;
  using Core.Models;
  using Microsoft.Practices.Unity;
  using Prism.Modularity;
  using Prism.Regions;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using ViewModels;
  using Views;

  public class FileItemListViewModule : IModule
  {
    private readonly IUnityContainer container;
    private readonly IRegionManager regionManager;

    public FileItemListViewModule(IRegionManager regionManager, IUnityContainer container)
    {
      this.regionManager = regionManager;
      this.container = container;
    }

    public void Initialize()
    {
      this.container.RegisterType<IFileItemListViewModel, FileItemListViewModel>();

      this.container.RegisterType<IFileItemViewModel, FileItemViewModel>(new InjectionConstructor(typeof(string), typeof(FileItemType), typeof(IFileItemService)));

      this.regionManager.RegisterViewWithRegion(RegionNames.FileItemListViewRegion, typeof(FileItemListView));
    }
  }
}