using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static System.Environment;

namespace GhisPrism.Package.ViewModels
{
    public class SourcesViewModel : BindableBase, ISourcesViewModel
    {
        private readonly IEventAggregator eventAggregator;
        private SpecialFolder selectedSource;

        public SourcesViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.LoadSourcesAsync();
        }

        public SpecialFolder SelectedSource
        {
            get => this.selectedSource;
            set
            {
                if (this.SetProperty(ref this.selectedSource, value))
                {
                    // this.eventAggregator.GetEvent<SpecialFolder>()
                }
            }
        }

        public ObservableCollection<SpecialFolder> SourceCollection { get; } = new ObservableCollection<SpecialFolder>();

        private async void LoadSourcesAsync()
        {
            await Task.Delay(1000);
            this.SourceCollection.Add(SpecialFolder.Desktop);
            this.SourceCollection.Add(SpecialFolder.ProgramFilesX86);
        }
    }
}