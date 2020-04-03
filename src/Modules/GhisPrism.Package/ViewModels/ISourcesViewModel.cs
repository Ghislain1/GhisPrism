using System.Collections.ObjectModel;
using static System.Environment;

namespace GhisPrism.Package.ViewModels
{
    public interface ISourcesViewModel
    {
        ObservableCollection<SpecialFolder> SourceCollection { get; }
    }
}