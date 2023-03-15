using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using ModsUpdater.ViewModels;

namespace ModsUpdater.Views
{
    public partial class VersionsListView : UserControl
    {
        public VersionsListView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<VersionsListViewModel>();

        }
    }
}
