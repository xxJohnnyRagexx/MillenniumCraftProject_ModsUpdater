using CommunityToolkit.Mvvm.ComponentModel;
using ModsUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ModsUpdater.ViewModels
{
    public class SettingsItemViewModel : ViewModelBase
    {
        private SettingsModel _model;

        public string GamePath
        {
            get => _model.GamePath;
            set => _model.GamePath = value;
        }

        public SettingsItemViewModel(SettingsModel settingsModel) 
        {
            GamePath = OSPlatform.Linux.ToString();
            _model = settingsModel;
        }

        public SettingsItemViewModel()
        {
            if (OperatingSystem.IsWindows())
                _model = new SettingsModel
                {
                    GamePath = Environment.ExpandEnvironmentVariables(AppSettings.Default.GamePathWin),
                };
            if (OperatingSystem.IsLinux())
            {
                _model = new SettingsModel
                {
                    GamePath = Environment.ExpandEnvironmentVariables(AppSettings.Default.GamePathLinux),
                };
            }
        }
    }
}
