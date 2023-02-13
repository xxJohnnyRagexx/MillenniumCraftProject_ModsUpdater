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
        public RelayCommand GoToSettingsCommand { get; set; }
        public RelayCommand GoToHomeCommand { get; set; }

        public ViewModelBase List
        {
            get => _content;
            private set => this.SetProperty(ref _content, value);

        }

        public MainWindowViewModel()
        {
            List = new VersionsListViewModel();

            GoToSettingsCommand = new RelayCommand(goToSettingsExecute, goToSettingsCanExecute);
            GoToHomeCommand = new RelayCommand(goToHomeExecute, goToHomeCanExecute);
        }

        private void goToSettingsExecute()
        {
            _content = List = new SettingsViewModel();
        }
        private bool goToSettingsCanExecute()
        {
            return true;
        }

        private void goToHomeExecute()
        {
            _content = List = new VersionsListViewModel();
        }

        private bool goToHomeCanExecute() 
        {
            return true;
        }
    }
}
