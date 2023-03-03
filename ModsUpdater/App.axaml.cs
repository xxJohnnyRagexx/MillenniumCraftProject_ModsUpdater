using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using ModsUpdater.ViewModels;
using ModsUpdater.Views;

namespace ModsUpdater
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
           Ioc.Default.ConfigureServices
                (new ServiceCollection()
                .AddTransient<UpdatesInfoRepository>()
                .AddTransient<SettingsItemViewModel>()
                .AddTransient<VersionsListViewModel>()
                .AddTransient<SettingsItemViewModel>()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<VersionsViewModel>()
                .AddSingleton<ViewModelBase>()
                .BuildServiceProvider()
                ); 
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}