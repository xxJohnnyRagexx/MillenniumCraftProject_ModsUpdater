using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Business;
using CommunityToolkit.Mvvm.DependencyInjection;
using DAL;
using Downloader;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using ModsUpdater.ViewModels;
using ModsUpdater.Views;
using UpdatesServiceHttpClient;

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
                .AddTransient<IUpdatesInfoRepository, UpdatesInfoRepository>()
                .AddSingleton<ILiteDatabase, LiteDatabase>(provider =>
                    new LiteDatabase($"Filename={Path.Combine(Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData), "updates.db")}")
                )
                .AddTransient<IUpdatesClient, UpdatesClient>()
                .AddTransient<IUpdaterService, UpdaterService>()
                .AddTransient<IDownloadService, DownloadService>(provider => new DownloadService(
                    new DownloadConfiguration
                {
                    MaximumBytesPerSecond = 1024 * 1024 * 1,
                    ReserveStorageSpaceBeforeStartingDownload = true,
                }))
                .AddTransient<SettingsItemViewModel>()
                .AddTransient<VersionsListViewModel>()
                .AddTransient<MainWindowViewModel>()
                .AddTransient<SettingsViewModel>()
                .AddTransient<VersionsViewModel>()
                .BuildServiceProvider()
                ); 
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}