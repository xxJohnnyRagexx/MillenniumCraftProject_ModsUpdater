using FakeDAL.Models;

namespace FakeDAL
{
    public interface IFakeUpdatesClient
    {
        List<UpdatesResponse> FetchUpdatesData();
    }
}