using Shared.Models;
using Shared.Services;

namespace ConsoleApp;

public class MenuService(CustomerService customerService, OrderService orderService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly OrderService _orderService = orderService;

    public void Run()
    {
        Console.WriteLine("Adding Customers");
        _customerService.CreateCustomer(new Customer { Name = "Hans Mattin-Lassei", Email = "hans@domain.com" });
        _customerService.CreateCustomer(new Customer { Name = "Tommy Mattin-Lassei", Email = "tommy@domain.com" });


        Console.ReadKey();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Customers using CustomerService");
        foreach (var customer in _customerService.GetAllCustomers())
            Console.WriteLine(customer.DisplayName);


        Console.ReadKey();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Customers using OrderService");
        foreach (var customer in _orderService.GetAllCustomers())
            Console.WriteLine(customer.DisplayName);


        Console.ReadKey();
    }
}
