using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ModsUpdater.ViewModels
{
    public class SettingsViewModel: ViewModelBase
    {
        public SettingsItemViewModel Item { get; set; }

        public SettingsViewModel(IConfiguration configuration) 
        {
            Item = new SettingsItemViewModel(configuration);
        }
    }
}
