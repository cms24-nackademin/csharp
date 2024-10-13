using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace MainApp.Menus;

internal class CustomerMenu
{
    private readonly CustomerService _customerService = new CustomerService();

    public void CreateMenu()
    {
        Customer customer = new Customer();

        Console.Clear();
        Console.WriteLine("Create New Customer");

        Console.Write("Enter Customer Name: ");
        customer.Name = Console.ReadLine() ?? "";

        Console.Write("Enter Customer Email: ");
        customer.Email = Console.ReadLine() ?? "";

        Console.Write("Enter Customer Phone: ");
        customer.Phone = Console.ReadLine() ?? "";

        var result = _customerService.AddToList(customer);

        switch(result)
        {
            case ResultStatus.Success:
                Console.WriteLine("\nCustomer was created successfully.");
                break;

            case ResultStatus.Exists:
                Console.WriteLine("\nCustomer with the same email already exists.");
                break;

            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while creating the customer.");
                break;

            case ResultStatus.SuccessWithErrors:
                Console.WriteLine("\nCustomer was created successfully. But customer list was not saved.");
                break;
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }


    public void ViewAllMenu()
    {
        var customerList = _customerService.GetAllCustomers();

        Console.Clear();
        Console.WriteLine("View All Customers\n");

        if (customerList.Any())
        {
            foreach (Customer customer in customerList)
            {
                Console.WriteLine($"{customer.Name} <{customer.Email}>");
                Console.WriteLine($"Phone. {customer.Phone}\n");
            }
        }
        else
        {
            Console.WriteLine("No customers in list\n");
        }


        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }


    public void ViewSingleMenu()
    {
        Console.Clear();
        Console.WriteLine("View Single Customer\n");

        Console.Write("Enter Customer Email: ");
        var email = Console.ReadLine() ?? "";

        var customer = _customerService.GetCustomer(email);
        
        if (customer != null)
        {
            Console.Clear();
            Console.WriteLine($"View Details for {customer.Name}\n");

            Console.WriteLine("Name:".PadRight(10)  + $"{customer.Name}");
            Console.WriteLine("Email:".PadRight(10) + $"{customer.Email}");
            Console.WriteLine("Phone:".PadRight(10) + $"{customer.Phone}\n");
        }
        else
        {
            Console.WriteLine($"No customer was found.\n");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    internal void DeleteMenu()
    {
        Console.Clear();
        Console.WriteLine("Delete Customer\n");

        Console.Write("Enter Customer Email: ");
        var email = Console.ReadLine() ?? "";

        var result = _customerService.DeleteCustomer(email);

        switch (result)
        {
            case ResultStatus.Success:
                Console.WriteLine("Customer was deleted successfully.");
                break;

            case ResultStatus.NotFound:
                Console.WriteLine("Customer was not found.");
                break;

            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while deleting the customer.");
                break;

            case ResultStatus.SuccessWithErrors:
                Console.WriteLine("\nCustomer was deleted successfully. But customer list was not saved.");
                break;
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}
