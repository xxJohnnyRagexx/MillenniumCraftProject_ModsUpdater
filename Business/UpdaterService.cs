using System.Globalization;
using Business.Dto;
using DAL;
using Downloader;
using UpdatesServiceHttpClient;

namespace Business
{
    public class UpdaterService : IUpdaterService
    {
        private readonly IUpdatesClient _updatesClient;
        private readonly IDownloadService _downloadService;
        private readonly IUpdatesInfoRepository _repository;
        public UpdaterService(IUpdatesClient updatesClient, IDownloadService downloadService, IUpdatesInfoRepository updatesInfoRepository)
        {
            _updatesClient = updatesClient;
            _downloadService = downloadService; 
            _repository = updatesInfoRepository;  
        }

        public async Task<List<UpdateItemDto>> GetUpdates()
        {
            var q = await _updatesClient.FetchUpdates();
            return q.Select(x => x.ToDto()).ToList();
        }

        public async Task GetUpdateAsync(string version, EventHandler<DownloadProgressChangedEventArgs> downloadProcessChanged)
        {
            string file = @"/home/marko/Загрузки/testpack.tar.gz";
            string url = $"http://localhost:5000/api/updates-service/update?gameVersion={version}";
            _downloadService.DownloadProgressChanged += downloadProcessChanged;
            await _downloadService.DownloadFileTaskAsync(url, file);

        }
    }
}
