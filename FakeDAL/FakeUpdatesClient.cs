using FakeDAL.Models;

namespace FakeDAL
{
    public class FakeUpdatesClient : IFakeUpdatesClient
    {
        private List<UpdatesResponse> _updatesResponses;
        public FakeUpdatesClient()
        {
            _updatesResponses = new List<UpdatesResponse>
            {
                new UpdatesResponse
                {
                    Version = "0.1",
                    GameVersion= "1.12.2",
                    Description="В этой версии добавлено то и это и пятое и десятое, поэтому качайте, вам понравится.",
                    Url = "Url",
                },

                new UpdatesResponse
                {
                    Version = "0.4",
                    GameVersion = "1.19.2",
                    Description = "А тут в дополнение к предыдущему ещё кое-что, вот список, читайте, радуйтесь жизни.",
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