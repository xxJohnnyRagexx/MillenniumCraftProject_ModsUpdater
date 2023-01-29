using FakeDAL.Models;

namespace FakeDAL
{
    public class UpdatesClient : IUpdatesClient
    {
        private List<UpdatesResponse> _updatesResponses;
        public UpdatesClient()
        {
            _updatesResponses = new List<UpdatesResponse>
            {
                new UpdatesResponse
                {
                    Version = "0.1",
                    GameVersion= "1.12.2",
                    Url = "Url",
                },

                new UpdatesResponse
                {
                    Version = "0.4",
                    GameVersion = "1.19.2",
                    Url = "Url"
                }
            };
        }

        public List<UpdatesResponse> FetchUpdatesData()
        {
            return _updatesResponses;
        }
    }
}