using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainApp.Services;

namespace MainApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    public async Task GoToDetails()
    {
        Product product = new Product { Name = "Product 1" };

        ProvisionedState.CurrentProduct = product;


        var navigationParameter = new Dictionary<string, object>
        {
            { "Product", product }
        };
        await Shell.Current.GoToAsync($"//DetailPage", navigationParameter);
    }
}

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
}
