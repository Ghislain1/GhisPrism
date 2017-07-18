using GhisPrism.Core;
using GhisPrism.Core.Models;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhisPrism.FileExplorerTreeView.ViewModels
{
  public class FileItemListViewModel : BindableBase, IFileItemListViewModel
  {
    private readonly IUnityContainer container;
    private IFileItemService fileItemService;

    public FileItemListViewModel(IFileItemService fileItemService, IUnityContainer container)
    {
      this.fileItemService = fileItemService;
      this.container = container;

      // Get the logical drives
      var children = this.fileItemService.GetLogicalDrives();

      var dataList = children.Select(drive => new FileItemViewModel(drive.FullPath, drive.Type));

      // Create the view models from the data
      this.Items = new ObservableCollection<IFileItemViewModel>(dataList);
    }

    /// <summary>
    /// A list of all directories on the machine
    /// </summary>
    public ObservableCollection<IFileItemViewModel> Items { get; set; }
  }
}