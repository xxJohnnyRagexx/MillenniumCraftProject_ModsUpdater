using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using ModsUpdater.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModsUpdater.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        private ViewModelBase _content;
        private readonly ViewModelBase _versionsListViewModel;
        private readonly ViewModelBase _settingsViewModel;
        public RelayCommand GoToSettingsCommand { get; set; }
        public RelayCommand GoToHomeCommand { get; set; }

        public ViewModelBase List
        {
            get => _content;
            private set => this.SetProperty(ref _content, value);
        }

        public ViewModelBase Settings
        {
            get => _content;
            private set => this.SetProperty(ref _content, value);
        }

        public MainWindowViewModel(SettingsViewModel settingsViewModel, VersionsListViewModel versionsListViewModel1)
        {
            _settingsViewModel = settingsViewModel;
            _versionsListViewModel = versionsListViewModel1;
            List = _versionsListViewModel;

            GoToSettingsCommand = new RelayCommand(goToSettingsExecute, goToSettingsCanExecute);
            GoToHomeCommand = new RelayCommand(goToHomeExecute, goToHomeCanExecute);
        }

        private void goToSettingsExecute()
        {
            _content = Settings = _settingsViewModel;
        }
        private bool goToSettingsCanExecute()
        {
            return true;
        }

        private void goToHomeExecute()
        {
            _content = List = _versionsListViewModel;
        }

        private bool goToHomeCanExecute() 
        {
            return true;
        }
    }
}
