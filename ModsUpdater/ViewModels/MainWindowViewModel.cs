using Avalonia.Controls.Selection;
using Business;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ModsUpdater.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<VersionsViewModel> VersionsList { get; set; }

        public string ShowedDescription { get; set; }

        private VersionsViewModel selectedItem;

        public VersionsViewModel SelectedItem
        {
            get => selectedItem;
            set => this.SetProperty(ref selectedItem, value);
        }

        private readonly UpdaterService _updaterService = new UpdaterService();
        public MainWindowViewModel() 
        {
            var data = _updaterService.GetUpdates();
            VersionsList = new ObservableCollection<VersionsViewModel>(data.Select(
                x => new VersionsViewModel
                (
                    x.ToModel()
                )
            ));
        }

    }
}