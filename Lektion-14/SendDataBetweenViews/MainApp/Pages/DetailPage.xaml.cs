using MainApp.ViewModels;

namespace MainApp.Pages;


[QueryProperty(nameof(Product), "Product")]
public partial class DetailPage : ContentPage
{
    Product product;
    public Product Product
    {
        get => product;
        set
        {
            product = value;
            OnPropertyChanged();
        }
    }

    public DetailPage(DetailsViewModel vm)
	{
		InitializeComponent();
        vm.CurrentProduct = Product;
		BindingContext = vm;
	}
}