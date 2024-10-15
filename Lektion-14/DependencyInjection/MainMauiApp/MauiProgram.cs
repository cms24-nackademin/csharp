using MainMauiApp.ViewModels;
using Microsoft.Extensions.Logging;
using Shared.Models;
using Shared.Services;

namespace MainMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(directoryPath, "customers.json");

            builder.Services.AddScoped(sp => new FileService(filePath));
            builder.Services.AddTransient<DataService<Customer>>();

            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<OrderService>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
