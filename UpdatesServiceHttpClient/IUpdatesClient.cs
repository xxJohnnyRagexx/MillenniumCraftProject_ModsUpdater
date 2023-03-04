namespace UpdatesServiceHttpClient
{
    public interface IUpdatesClient
    {
        Task<List<UpdatesResponse>> FetchUpdates();
    }
}