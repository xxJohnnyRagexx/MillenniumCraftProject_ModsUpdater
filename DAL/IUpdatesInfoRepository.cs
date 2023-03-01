namespace DAL
{
    public interface IUpdatesInfoRepository
    {
        Task<UpdateInfoEntity> GetUpdateInfoAsync(string gameVersion);
        Task<List<UpdateInfoEntity>> GetUpdatesInfoAsync();
        Task WriteUpdateInfoAsync(UpdateInfoEntity entity);
    }
}