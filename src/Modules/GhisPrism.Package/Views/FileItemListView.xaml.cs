using System.Windows.Controls;

namespace GhisPrism.Package.Views
{
    /// <summary>
    /// Interaction logic for FileItemListView.xaml
    /// </summary>
    public partial class FileItemListView : UserControl
    {
        public FileItemListView(IFileItemListViewModel fileItemListViewModel)
        {
            InitializeComponent();
            this.DataContext = fileItemListViewModel;
        }
    }
}