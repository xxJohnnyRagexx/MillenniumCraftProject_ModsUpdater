using Avalonia.Controls.Selection;
using Avalonia.Controls.Templates;
using Business;
using CommunityToolkit.Mvvm.Input;
using Downloader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModsUpdater.ViewModels
{
    public class VersionsListViewModel : ViewModelBase
    {
        private string _state;
        private int _progress;
        private VersionsViewModel _selectedItem;
        public Task<ObservableCollection<VersionsViewModel>> Versions => GetVersionsListAsync();
        public string State 
        {   
            get => _state;
            set => SetProperty(ref _state, value);
        }
        public ICommand DownloadFileCommand { get; }
        public int Progress
        {
            get => _progress;
            set => this.SetProperty(ref _progress, value);
        }
        public VersionsViewModel SelectedItem
        {
            get => _selectedItem;
            set => this.SetProperty(ref _selectedItem, value);
        }
        private readonly IUpdaterService _updaterService;
        public VersionsListViewModel(IUpdaterService updaterService)
        {
            _updaterService = updaterService;
            DownloadFileCommand = new AsyncRelayCommand(DownloadUpdates);
        }
        private async Task<ObservableCollection<VersionsViewModel>> GetVersionsListAsync()
        {
            State = "Получение списка обновлений";
            try
            {
                var data = await _updaterService.GetUpdates();
                State = "Готово";
                return new ObservableCollection<VersionsViewModel>(
                    data.Select(
                        x => new VersionsViewModel(
                            x.ToModel()
                        ))
                );
            }
            catch (Exception e)
            {
                State = $"{e.Message}";
                return new ObservableCollection<VersionsViewModel>();
            }
        }
        private async Task DownloadUpdates()
        {
            Progress = 0;
            if (_selectedItem != null)
            {
                await _updaterService.GetUpdateAsync
                (_selectedItem.GameVersion, (sender, e) => 
                    { Progress = Convert.ToInt32(e.ProgressPercentage * 100); }
                );
            }
        }
    }
}