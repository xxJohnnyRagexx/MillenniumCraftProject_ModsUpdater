using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UpdatesServiceHttpClient
{
    public class UpdatesResponse
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }
        [JsonPropertyName("gameVersion")]
        public string GameVersion { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
