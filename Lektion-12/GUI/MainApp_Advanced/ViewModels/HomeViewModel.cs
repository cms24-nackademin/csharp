using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Shared.Models;
using Shared.Services;
using System.Collections.ObjectModel;

namespace MainApp_Advanced.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly CustomerService _customerService;

    [ObservableProperty]
    private ObservableCollection<Customer> _customers = [];

    [ObservableProperty]
    private Customer _currentCustomer = new();


    public HomeViewModel(IServiceProvider serviceProvider, CustomerService customerService)
    {
        _serviceProvider = serviceProvider;
        _customerService = customerService;
        GetCustomers();
    }

    public void GetCustomers()
    {
        Customers.Clear();
        foreach (var customer in _customerService.GetCustomers())
            Customers.Add(customer);
    }


    [RelayCommand]
    public void GoToSettings()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<SettingsViewModel>();
    }

    [RelayCommand]
    public void Save()
    {
        _customerService.AddToList(CurrentCustomer);
    }

    [RelayCommand]
    public void Delete(Customer customer)
    {

    }
}
