using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Models;
using Shared.Services;
using System.IO;
using System.Windows;
using WpfApp.ViewModels;

namespace WpfApp;

public partial class App : Application
{
    private IHost builder;

	public App()
	{
        builder = Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
        {
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(directoryPath, "customers.json");

            services.AddScoped(sp => new FileService(filePath));
            services.AddScoped<DataService<Customer>>();

            services.AddSingleton<CustomerService>();
            services.AddSingleton<OrderService>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();

        }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = builder.Services.GetRequiredService<MainWindow>();
        mainWindow.DataContext = builder.Services.GetRequiredService<MainViewModel>();
        MainWindow.Show();
    }
}
