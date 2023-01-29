using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDAL.Models
{
    public class UpdatesResponse
    {
        public string Version { get; set; }
        public string GameVersion { get; set; }
        public string Url { get; set; }
    }
}
