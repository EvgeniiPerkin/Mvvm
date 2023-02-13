using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mvvm.Models;
using Mvvm.Services;
using Mvvm.ViewModels;
using Mvvm.Views;
using System.Windows;

namespace Mvvm
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddTransient<IService, Service>();
                services.AddTransient<IDataModel, DataModel>();
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm!.DataContext = new MainWindowViewModel(new DataModel { Data = "" });
            startupForm!.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e) 
        {
            await AppHost!.StopAsync();
            base.OnExit(e);            
        }
    }
}
