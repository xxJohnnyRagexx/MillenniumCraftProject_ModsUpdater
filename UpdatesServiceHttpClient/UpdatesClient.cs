using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UpdatesServiceHttpClient
{
    public class UpdatesClient : IUpdatesClient
    {
        private readonly string _url;
        private readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000/api/updates-service/"),
        };
        public UpdatesClient(string url = "http://localhost:5000/api/updates-service/")
        {
            _url = url;
        }

        public async Task<List<UpdatesResponse>> FetchUpdates()
        {
            var response = await httpClient.GetStringAsync("fetch-updates");
            var q = JsonSerializer.Deserialize<List<UpdatesResponse>>(response);
            return q;
        }
    }
}
