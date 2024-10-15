using ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Models;
using Shared.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
{
    var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
    var filePath = Path.Combine(directoryPath, "customers.json");

    services.AddScoped(sp => new FileService(filePath));
    services.AddScoped<DataService<Customer>>();

    services.AddSingleton<CustomerService>();
    services.AddSingleton<OrderService>();
    services.AddSingleton<MenuService>();

}).Build();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.Run();