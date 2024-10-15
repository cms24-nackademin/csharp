using CommunityToolkit.Mvvm.ComponentModel;
using Shared.Models;
using Shared.Services;
using System.Collections.ObjectModel;

namespace WpfApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly CustomerService _customerService;
    private readonly OrderService _orderService;

    [ObservableProperty]
    private ObservableCollection<Customer> customerServiceList = [];

    [ObservableProperty]
    private ObservableCollection<Customer> orderServiceList = [];

    public MainViewModel(CustomerService customerService, OrderService orderService)
    {
        _customerService = customerService;
        _orderService = orderService;

        _customerService.CreateCustomer(new Customer { Name = "Hans Mattin-Lassei", Email = "hans@domain.com" });
        _customerService.CreateCustomer(new Customer { Name = "Tommy Mattin-Lassei", Email = "tommy@domain.com" });

        foreach (var customer in _customerService.GetAllCustomers())
            CustomerServiceList.Add(customer);

        foreach (var customer in _orderService.GetAllCustomers())
            OrderServiceList.Add(customer);

    }


}
