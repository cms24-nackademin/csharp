using Shared.Models;

namespace Shared.Services;

public class CustomerService(DataService<Customer> dataService)
{
    private readonly DataService<Customer> _dataService = dataService;

    public void CreateCustomer(Customer customer)
    {
        _dataService.AddToList(customer);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _dataService.GetAll();
    }
}
