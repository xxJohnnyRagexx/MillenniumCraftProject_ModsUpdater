using LiteDB.Async;

namespace DAL
{
    public class UpdatesInfoRepository : IUpdatesInfoRepository
    {
        private readonly ILiteDatabaseAsync _database;
        private string filepath = Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "updates.db").ToString();
        public UpdatesInfoRepository(ILiteDatabaseAsync database)
        {
            _database = database; //new LiteDatabaseAsync($"Filename={filepath};");
        }

        public async Task<UpdateInfoEntity> GetUpdateInfoAsync(string gameVersion)
        {
            var collection = _database.GetCollection<UpdateInfoEntity>();
            return await collection.Query().Where(x => x.GameVersion == gameVersion).FirstOrDefaultAsync();
        }

        public async Task<List<UpdateInfoEntity>> GetUpdatesInfoAsync()
        {
            return await _database.GetCollection<UpdateInfoEntity>()
                .Query()
                .ToListAsync();
        }

        public async Task WriteUpdateInfoAsync(UpdateInfoEntity entity)
        {
            var collection = _database.GetCollection<UpdateInfoEntity>();
            await collection.InsertAsync(entity);
        }
    }
}