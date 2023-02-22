namespace UpdatesServiceHttpClient
{
    public interface IUpdatesClient
    {
        List<UpdatesResponse> FetchUpdates();
    }
}