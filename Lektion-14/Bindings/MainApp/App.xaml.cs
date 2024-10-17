using MainApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MainApp;

public partial class App : Application
{
    private IHost builder;

	public App()
	{
		builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
		{
			services.AddSingleton<ProductService>();
			services.AddSingleton<MainViewModel>();
			services.AddSingleton<MainWindow>();
		}).Build();
	}


    protected override void OnStartup(StartupEventArgs e)
    {
		var mainWindow = builder.Services.GetRequiredService<MainWindow>();
		mainWindow.DataContext = builder.Services.GetRequiredService<MainViewModel>();
		mainWindow.Show();
    }
}
