using FakeDAL.Models;

namespace FakeDAL
{
    public interface IUpdatesClient
    {
        List<UpdatesResponse> FetchUpdatesData();
    }
}