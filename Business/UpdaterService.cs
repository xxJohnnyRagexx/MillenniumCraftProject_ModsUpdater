using Business.Dto;
using Downloader;
using FakeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdatesServiceHttpClient;

namespace Business
{
    public class UpdaterService
    {
        private readonly IUpdatesClient _updatesClient;
        private readonly IDownloadService _downloadService;
        public UpdaterService(IUpdatesClient updatesClient) { }

        public UpdaterService()
        {
            var downloadOptions = new DownloadConfiguration
            {
                MaximumBytesPerSecond = 1024 * 1024 * 5,
                ReserveStorageSpaceBeforeStartingDownload = true,
            };
            _updatesClient = new UpdatesClient();
            _downloadService = new DownloadService(downloadOptions);
        }

        public List<UpdateItemDto> GetUpdates()
        {
            var q  = _updatesClient.FetchUpdates().Select(
                x => x.ToDto()
               ).ToList();

            return q;
        }

        public async Task GetUpdateAsync(string version, EventHandler<DownloadProgressChangedEventArgs> downloadProcessChanged)
        {
            string file = @"D:\DownLoadedFile.zip";
            //string url = $"http://localhost:5000/update/?gameVersion={version}";
            string url = @"https://dl.zaycev.net/track/24922020/3gyDk3fqEpGD676kKB5rkkSkn4dK5aKCWEvjqHzytAuQka6hmwUGbugmH6CgGqHnyQWv3X1knCDrd2r5HboUKrhmn1uLUGkY9VMhshVuAx12QYQoWvNsa8TmkJcXykrYoksd2JTqhgN6RbWyuR9TRUHXn7SFvkXKAbv9CNw6BfyT4DkBoYuFZAo97UVceNu3p7WubbfmHGpY8pYmK4ttZJt9GQNSiHyigDFD2STcDYZbn8ReMiriBWoLqSFXxz3X7KTDMmiMVSvN8royZJiU6kWPvEy1aStTjJYprvkBZUF8waFGaoB9m9QFDuMsfDnzfqoLNtyGcm2MXErTp9f3WHTNGA26iaWB4pY5QdfE5MsnTnRjbYzJRWxRHSXGKSeaPnGUWjA7iy";
            _downloadService.DownloadProgressChanged += downloadProcessChanged;
            await _downloadService.DownloadFileTaskAsync(url, file);
            
            //BaseUrl/update/{version}
        }
    }
}
