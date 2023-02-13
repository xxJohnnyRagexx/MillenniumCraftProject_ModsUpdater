using Avalonia.Controls;
using ModsUpdater.ViewModels;

namespace ModsUpdater.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
        }
    }
}
