namespace GhisPrism.Package.ViewModels
{
    using Core;
    using Core.Models;
    using Prism.Commands;
    using Prism.Mvvm;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Linq;

    public class FileItemViewModel : BindableBase, IFileItemViewModel
    {
        private readonly IFileItemService fileItemService;

        public FileItemViewModel(string fullPath, FileItemType type)
        {
            // Create commands
            this.ExpandCommand = new DelegateCommand(Expand);

            // Set path and type
            this.FullPath = fullPath;
            this.Type = type;

            // Setup the children as needed
            this.ClearChildren();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="type">The type of item</param>
        public FileItemViewModel(string fullPath, FileItemType type, IFileItemService fileItemService)
        {
            this.fileItemService = fileItemService;

            // Create commands
            this.ExpandCommand = new DelegateCommand(Expand);

            // Set path and type
            this.FullPath = fullPath;
            this.Type = type;

            // Setup the children as needed
            this.ClearChildren();
        }

        /// <summary>
        /// Indicates if this item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != FileItemType.File; } }

        /// <summary>
        /// A list of all children contained inside this item
        /// </summary>
        public ObservableCollection<IFileItemViewModel> Children { get; set; }

        /// <summary>
        /// The command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        /// <summary>
        /// The full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Indicates if the current item is expanded or not
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // If the UI tells us to close
                else
                    this.ClearChildren();
            }
        }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name
        {
            get
            {
                return this.Type == FileItemType.Drive ? this.FullPath : this.fileItemService.GetFileFolderName(this.FullPath);
            }
        }

        /// <summary>
        /// The type of this item
        /// </summary>
        public FileItemType Type { get; set; }

        /// <summary>
        /// Removes all children from the list, adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            // Clear items
            this.Children = new ObservableCollection<IFileItemViewModel>();

            // Show the expand arrow if we are not a file
            if (this.Type != FileItemType.File)
                this.Children.Add(null);
        }

        /// <summary>
        /// Expands this directory and finds all children
        /// </summary>
        private void Expand()
        {
            // We cannot expand a file
            if (this.Type == FileItemType.File)
                return;

            // Find all children
            var children = this.fileItemService.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<IFileItemViewModel>(
                                children.Select(content => new FileItemViewModel(content.FullPath, content.Type)));
        }
    }
}