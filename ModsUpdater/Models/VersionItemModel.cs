using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsUpdater.Models
{
    public class VersionItemModel
    {
        public string Version { get; set; }
        public string GameVersion { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsInstalled { get; set; }
    }
}
