using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using ModsUpdater.ViewModels;

namespace ModsUpdater.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<SettingsViewModel>();
        }
    }
}
