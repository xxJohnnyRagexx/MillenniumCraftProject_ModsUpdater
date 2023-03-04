using LiteDB;
using LiteDB.Async;

namespace DAL
{
    public class UpdatesInfoRepository : IUpdatesInfoRepository
    {
        private readonly ILiteDatabase _database;
        private string filepath = Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "updates.db").ToString();
        public UpdatesInfoRepository(ILiteDatabase database)
        {
            _database = database; //new LiteDatabaseAsync($"Filename={filepath};");
        }

        public UpdateInfoEntity GetUpdateInfoAsync(string gameVersion)
        {
            var collection = _database.GetCollection<UpdateInfoEntity>();
            return collection.Query().Where(x => x.GameVersion == gameVersion).FirstOrDefault();
        }

        public List<UpdateInfoEntity> GetUpdatesInfoAsync()
        {
            return _database.GetCollection<UpdateInfoEntity>()
                .Query()
                .ToList();
        }

        public void WriteUpdateInfoAsync(UpdateInfoEntity entity)
        {
            var collection = _database.GetCollection<UpdateInfoEntity>();
            collection.Insert(entity);
        }
    }
}