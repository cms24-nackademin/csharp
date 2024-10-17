using MainApp.ViewModels;

namespace MainApp.Pages;
public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}