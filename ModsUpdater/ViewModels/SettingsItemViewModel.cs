using ModsUpdater.Models;
using System;
using System.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace ModsUpdater.ViewModels
{
    public class SettingsItemViewModel : ViewModelBase
    {
        private SettingsModel _model;
        private readonly IConfiguration _configuration;
        public string ServerUrl
        {
            get => _model.ServerUrl;
            set => _model.ServerUrl = value;
        }

        public string GamePath
        {
            get => _model.GamePath;
            set => _model.GamePath = value;
        }

        public SettingsItemViewModel(SettingsModel settingsModel, IConfiguration configuration) 
        {
            _model = settingsModel;
            _configuration = configuration;
        }

        public SettingsItemViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
            if (OperatingSystem.IsWindows())
                _model = new SettingsModel
                {
                    GamePath = _configuration["GamePathWin"],
                };
            else if (OperatingSystem.IsLinux()) 
                _model = new SettingsModel
                {
                    GamePath = _configuration["GamePathLinux"],
                };
            _model.ServerUrl = _configuration["ServerUrl"];
        }
    }
}
