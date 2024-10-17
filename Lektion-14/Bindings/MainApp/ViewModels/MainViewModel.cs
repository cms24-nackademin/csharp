using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;

namespace MainApp.ViewModels;

public partial class MainViewModel(ProductService productService) : ObservableObject
{
    private readonly ProductService _productService = productService;

    [ObservableProperty]
    private CurrentProductItem currentItem = new();

    [ObservableProperty]
    private string invalidName;

    [ObservableProperty]
    private string invalidDescription;

    [ObservableProperty]
    private string invalidPrice;

    [RelayCommand]
    public void Save()
    {
        try
        {
            InvalidName = string.IsNullOrWhiteSpace(CurrentItem.Name) ? "You must enter a name" : "";
            InvalidDescription = string.IsNullOrWhiteSpace(CurrentItem.Description) ? "You must enter a description" : "";
            InvalidPrice = !decimal.TryParse(CurrentItem.Price, out decimal _) ? "You must enter valid price" : "";

            if (string.IsNullOrEmpty(InvalidName) && 
                string.IsNullOrEmpty(InvalidDescription) && 
                string.IsNullOrEmpty(InvalidPrice))
            {
                var result = _productService.SaveProduct(CurrentItem);
                if (result)
                {
                    CurrentItem = new();
                }
            }
        }
        catch
        {

        }
    }
}
