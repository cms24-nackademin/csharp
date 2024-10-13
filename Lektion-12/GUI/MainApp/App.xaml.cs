using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Services;
using System.IO;
using System.Windows;

namespace MainApp;

public partial class App : Application
{
    private readonly IHost _host;

	public App()
	{
		var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string filePath = Path.Combine(baseDirectory, "customers.json");

		_host = Host.CreateDefaultBuilder()
			.ConfigureServices((context, services) =>
			{
				services.AddSingleton<CustomerService>();
				services.AddSingleton<FileService>(new FileService(filePath));
				services.AddSingleton<MainWindow>();

            }).Build();
	}

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
		await _host.StartAsync();

		var mainWindow = _host.Services.GetRequiredService<MainWindow>();
		mainWindow.Show();
    }

}