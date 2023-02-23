using Avalonia.Controls.Selection;
using Avalonia.Controls.Templates;
using Business;
using CommunityToolkit.Mvvm.Input;
using Downloader;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ModsUpdater.ViewModels
{
    public class VersionsListViewModel : ViewModelBase
    {
        public ObservableCollection<VersionsViewModel> VersionsList { get; set; }

        public ICommand DownloadFileCommand { get; }

        private VersionsViewModel selectedItem;

        private int progress;

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

        private readonly UpdaterService _updaterService = new UpdaterService();
        private readonly DownloadService _downloadService = new DownloadService();
        public VersionsListViewModel() 
        {
            var data = _updaterService.GetUpdates();
            VersionsList = new ObservableCollection<VersionsViewModel>(data.Select(
                x => new VersionsViewModel
                (
                    x.ToModel()
                )
            ));
            DownloadFileCommand = new AsyncRelayCommand(async () =>
            {
                Progress = 0;
               // var url = @"https://dl.zaycev.net/track/24922020/3gyDk3fqEpGD676kKB5rkkSkn4dK5aKCWEvjqHzytAuQka6hmwUGbugmH6CgGqHnyQWv3X1knCDrd2r5HboUKrhmn1uLUGkY9VMhshVuAx12QYQoWvNsa8TmkJcXykrYoksd2JTqhgN6RbWyuR9TRUHXn7SFvkXKAbv9CNw6BfyT4DkBoYuFZAo97UVceNu3p7WubbfmHGpY8pYmK4ttZJt9GQNSiHyigDFD2STcDYZbn8ReMiriBWoLqSFXxz3X7KTDMmiMVSvN8royZJiU6kWPvEy1aStTjJYprvkBZUF8waFGaoB9m9QFDuMsfDnzfqoLNtyGcm2MXErTp9f3WHTNGA26iaWB4pY5QdfE5MsnTnRjbYzJRWxRHSXGKSeaPnGUWjA7iy";
                //var file = @"D:\Archive.zip";
                //_downloadService.DownloadProgressChanged += (sender, e) => { Progress = Convert.ToInt32(e.ProgressPercentage * 100); };
               // await _downloadService.DownloadFileTaskAsync(url, file);
                await _updaterService.GetUpdateAsync(selectedItem.GameVersion,  (sender, e) => {
                    Progress = Convert.ToInt32(e.ProgressPercentage * 100);
                }
                );
            });
        }

    }
}