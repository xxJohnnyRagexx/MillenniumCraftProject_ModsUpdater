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
        private string state;
        private int progress;
        private VersionsViewModel selectedItem;
        public Task<ObservableCollection<VersionsViewModel>> Versions => getVersionsListAsync();
        public string State 
        {   
            get => state;
            set => SetProperty(ref state, value);
        }
        public ICommand DownloadFileCommand { get; }
        public int Progress
        {
            get => progress;
            set => this.SetProperty(ref progress, value);
        }
        public VersionsViewModel SelectedItem
        {
            get => selectedItem;
            set => this.SetProperty(ref selectedItem, value);
        }
        private readonly IUpdaterService _updaterService;
        public VersionsListViewModel(IUpdaterService updaterService)
        {
            _updaterService = updaterService;
            DownloadFileCommand = new AsyncRelayCommand(downloadUpdates);
        }
        private async Task<ObservableCollection<VersionsViewModel>> getVersionsListAsync()
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
                State = $"Не удалось получить обновления {e.Message}";
                return new ObservableCollection<VersionsViewModel>();
            }
        }
        private async Task downloadUpdates()
        {
            Progress = 0;
            if (selectedItem != null)
            {
                await _updaterService.GetUpdateAsync
                (selectedItem.GameVersion, (sender, e) => 
                    { Progress = Convert.ToInt32(e.ProgressPercentage * 100); }
                );
            }
        }
    }
}