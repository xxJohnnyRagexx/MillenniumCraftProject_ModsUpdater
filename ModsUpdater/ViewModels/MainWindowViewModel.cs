using Avalonia.Controls;
using ModsUpdater.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModsUpdater.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            private set => this.SetProperty(ref _content, value);
        }

        public MainWindowViewModel()
        {
            Content = new VersionsListViewModel();
        }
    }
}
