using CommunityToolkit.Mvvm.ComponentModel;
using MainApp.Services;

namespace MainApp.ViewModels;

public partial class DetailsViewModel : ObservableObject
{
    [ObservableProperty]
    private Product currentProduct = new();


    public DetailsViewModel()
    {
        CurrentProduct = ProvisionedState.CurrentProduct;
    }
}
