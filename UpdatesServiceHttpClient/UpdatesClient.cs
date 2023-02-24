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
            BaseAddress = new Uri("https://localhost:7220/api/updates-service/"),
        };
        public UpdatesClient(string url = "http://localhost:7220/api/updates-service/")
        {
            _url = url;
        }

        public List<UpdatesResponse> FetchUpdates()
        {
            var response = httpClient.GetStringAsync("fetch-updates").Result;
            var q = JsonSerializer.Deserialize<List<UpdatesResponse>>(response);
            return q;
        }
    }
}
