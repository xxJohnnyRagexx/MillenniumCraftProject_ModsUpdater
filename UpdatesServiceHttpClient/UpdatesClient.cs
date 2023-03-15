using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UpdatesServiceHttpClient
{
    public class UpdatesClient : IUpdatesClient
    {
        private readonly string basePath;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient httpClient;

        public UpdatesClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            httpClient = _httpClientFactory.CreateClient();
            var appSettings = ConfigurationManager.AppSettings;
            basePath = appSettings["ServerUrl"];
        }

        public async Task<List<UpdatesResponse>> FetchUpdates()
        {
            var path = ConfigurationManager.AppSettings["ServerUrl"];
            var request = new HttpRequestMessage(
                HttpMethod.Get, $"{path}/fetch-updates");
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                await using var contentStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<UpdatesResponse>>(contentStream);
            }
            return new List<UpdatesResponse>();
        }
    }
}
