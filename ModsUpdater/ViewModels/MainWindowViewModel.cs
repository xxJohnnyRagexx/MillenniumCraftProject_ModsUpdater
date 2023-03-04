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
        private readonly VersionsListViewModel _versionsListViewModel;
        private readonly SettingsViewModel _settingsViewModel;
        public RelayCommand GoToSettingsCommand { get; set; }
        public RelayCommand GoToHomeCommand { get; set; }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.SetProperty(ref _content, value);
        }

        public MainWindowViewModel(SettingsViewModel settingsViewModel, VersionsListViewModel versionsListViewModel1)
        {
            _settingsViewModel = settingsViewModel;
            _versionsListViewModel = versionsListViewModel1;
            Content = _versionsListViewModel;

            GoToSettingsCommand = new RelayCommand(goToSettingsExecute, goToSettingsCanExecute);
            GoToHomeCommand = new RelayCommand(goToHomeExecute, goToHomeCanExecute);
        }

        private void goToSettingsExecute()
        {
            Content  = _settingsViewModel;
        }
        private bool goToSettingsCanExecute()
        {
            return true;
        }

        private void goToHomeExecute()
        {
            Content = _versionsListViewModel;
        }

        private bool goToHomeCanExecute() 
        {
            return true;
        }
    }
}
