using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsUpdater.ViewModels
{
    public class SettingsViewModel: ViewModelBase
    {
        public SettingsItemViewModel Item { get; set; }

        public SettingsViewModel() 
        {
            Item = new SettingsItemViewModel();

        }


    }
}
