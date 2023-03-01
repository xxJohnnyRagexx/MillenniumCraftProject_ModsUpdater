using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class UpdateItemDto
    {
        public string Version { get; set; }
        public string GameVersion { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
