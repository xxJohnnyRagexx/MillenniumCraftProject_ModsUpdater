using Business.Dto;
using DAL;
using Downloader;
using UpdatesServiceHttpClient;

namespace Business
{
    public class UpdaterService
    {
        private readonly IUpdatesClient _updatesClient;
        private readonly IDownloadService _downloadService;
        private readonly UpdatesInfoRepository _repository;
        public UpdaterService(IUpdatesClient updatesClient) { }

        public UpdaterService()
        {
            var downloadOptions = new DownloadConfiguration
            {
                MaximumBytesPerSecond = 1024 * 1024 * 1,
                ReserveStorageSpaceBeforeStartingDownload = true,
            };
            _updatesClient = new UpdatesClient();
            _downloadService = new DownloadService(downloadOptions);
        }

        public async Task<List<UpdateItemDto>> GetUpdates()
        {
            var q  = _updatesClient.FetchUpdates().Select(
                x => x.ToDto()
               ).ToList();

            var updatesInfo = await _repository.GetUpdatesInfoAsync();
            var items = updatesInfo.Select(x => x.ToDto());
            foreach (var item in items)
            {
                q.Remove(
                    q.Where(x => x.Version == item.Version 
                    && x.GameVersion == item.GameVersion)
                    .First()
                    );
            }
            return q;
        }

        public async Task GetUpdateAsync(string version, EventHandler<DownloadProgressChangedEventArgs> downloadProcessChanged)
        {
            string file = @"D:\DownLoadedFile.zip";
            string url = $"http://localhost:5000/api/updates-service/update?gameVersion={version}";
            _downloadService.DownloadProgressChanged += downloadProcessChanged;
            await _downloadService.DownloadFileTaskAsync(url, file);

        }
    }
}
