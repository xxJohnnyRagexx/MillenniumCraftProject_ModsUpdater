using Business.Dto;
using FakeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UpdaterService
    {
        private readonly IUpdatesClient _updatesClient;
        public UpdaterService(IUpdatesClient updatesClient) { }

        public UpdaterService()
        {
            _updatesClient = new UpdatesClient();
        }

        public List<UpdateItemDto> GetUpdates()
        {
            return _updatesClient.FetchUpdatesData().Select(
                x => x.ToDto()
                ).ToList();
        }
    }
}
