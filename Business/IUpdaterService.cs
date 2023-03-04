using Business.Dto;
using Downloader;

namespace Business
{
    public interface IUpdaterService
    {
        Task GetUpdateAsync(string version, EventHandler<DownloadProgressChangedEventArgs> downloadProcessChanged);
        Task<List<UpdateItemDto>> GetUpdates();
    }
}