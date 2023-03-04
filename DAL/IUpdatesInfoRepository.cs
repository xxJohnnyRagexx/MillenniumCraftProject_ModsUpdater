namespace DAL
{
    public interface IUpdatesInfoRepository
    {
        UpdateInfoEntity GetUpdateInfoAsync(string gameVersion);
        List<UpdateInfoEntity> GetUpdatesInfoAsync();
        void WriteUpdateInfoAsync(UpdateInfoEntity entity);
    }
}