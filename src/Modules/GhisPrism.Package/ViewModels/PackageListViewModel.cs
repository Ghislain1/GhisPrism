using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GhisPrism.Core;
using Prism.Mvvm;

namespace GhisPrism.Package.ViewModels
{
    public class PackageListViewModel : BindableBase
    {
        private readonly IChocolateyService chocolateyService;

        private ISourcesViewModel sourcesViewModel;

        public PackageListViewModel(IChocolateyService chocolateyService, ISourcesViewModel sourcesViewModel)
        {
            this.chocolateyService = chocolateyService ?? throw new ArgumentNullException(nameof(chocolateyService));
            this.sourcesViewModel = sourcesViewModel;

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
            var pks = await this.chocolateyService.GetInstalledPackages();
            this.PackageCollection.Clear();
            this.PackageCollection.AddRange(pks);
        }
    }
}
