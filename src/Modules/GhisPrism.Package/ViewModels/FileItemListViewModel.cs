using System.Collections.ObjectModel;
using System.Linq;

namespace GhisPrism.Package.ViewModels
{
    public class FileItemListViewModel : BindableBase, IFileItemListViewModel
    {
        private IFileItemService fileItemService;

        public FileItemListViewModel(IFileItemService fileItemService)
        {
            this.fileItemService = fileItemService;

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