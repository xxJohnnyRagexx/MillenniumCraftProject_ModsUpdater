using Avalonia.Controls;
using ModsUpdater.ViewModels;

namespace ModsUpdater.Views
{
    public partial class VersionsListView : UserControl
    {
        public VersionsListView()
        {
            InitializeComponent();
            DataContext = new VersionsListViewModel();
        }
    }
}
