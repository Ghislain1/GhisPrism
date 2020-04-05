using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GhisPrism.Package.ViewModels
{
    public class PackageListViewModel : BindableBase
    {
        private readonly IGhisSpecialFolderService ghisSpecialFolderService;

        private ISourcesViewModel sourcesViewModel;

        public PackageListViewModel(IGhisSpecialFolderService ghisSpecialFolderService, ISourcesViewModel sourcesViewModel)
        {
            this.ghisSpecialFolderService = ghisSpecialFolderService;
            this.sourcesViewModel = sourcesViewModel;
            this.ghisSpecialFolderService.AddSource(System.Environment.SpecialFolder.DesktopDirectory);

            this.LoadAsync();
        }

        public ObservableCollection<GhisPrism.Core.Models.Package> PackageCollection { get; } = new ObservableCollection<GhisPrism.Core.Models.Package>();

        public ISourcesViewModel SourcesViewModel
        {
            get => this.sourcesViewModel;
            set => this.SetProperty(ref this.sourcesViewModel, value);
        }

        private async void LoadAsync()
        {
            await Task.Delay(1000 * 1);
            var pks = await this.ghisSpecialFolderService.GetInstalledPackages();
            this.PackageCollection.Clear();
            this.PackageCollection.AddRange(pks);
        }
    }
}