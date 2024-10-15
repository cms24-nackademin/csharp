using Shared.Models;

namespace Shared.Services;

public class OrderService(DataService<Customer> dataService)
{
    private readonly DataService<Customer> _dataService = dataService;

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _dataService.GetAll();
    }
}
