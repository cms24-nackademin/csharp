using Newtonsoft.Json;
using Shared.Models;

namespace Shared.Services;


public class CustomerService
{
    private List<Customer> _customers = [];
    private readonly FileService _fileService;

    public CustomerService(FileService fileService)
    {
        _fileService = fileService;
    }


    public bool AddToList(Customer customer)
    {
        try
        {
            _customers.Add(customer);
            _fileService.SaveToFile(JsonConvert.SerializeObject(_customers));
            return true;
        }
        catch { }
        return false;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        var json = _fileService.GetFromFile();
        if (!string.IsNullOrEmpty(json))
        {
            _customers = JsonConvert.DeserializeObject<List<Customer>>(json)!;
        }

        return _customers;
    }

}
