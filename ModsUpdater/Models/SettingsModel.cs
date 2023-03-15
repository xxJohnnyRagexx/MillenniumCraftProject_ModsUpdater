using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsUpdater.Models
{
    public class SettingsModel
    { 
        public string GamePathLinux { get; set; }
        public string GamePathWin { get; set; }
        public string GamePath { get; set; }
        public string ServerUrl { get; set; }
    }
}
