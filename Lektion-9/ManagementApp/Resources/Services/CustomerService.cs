using Newtonsoft.Json;
using Resources.Enums;
using Resources.Models;

namespace Resources.Services;

public class CustomerService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json");
    private readonly FileService _fileService = new FileService(_filePath);
    private List<Customer> _customerList = new List<Customer>();

    public ResultStatus AddToList(Customer customer)
    {
        try
        {
            GetCustomersFromFile();

            if (_customerList.Any(c => c.Email == customer.Email))
                return ResultStatus.Exists;

            _customerList.Add(customer);
            
            var json = JsonConvert.SerializeObject(_customerList, Formatting.Indented);
            var result = _fileService.SaveToFile(json);
            if (result)
                return ResultStatus.Success;

            return ResultStatus.SuccessWithErrors;
        }
        catch
        {
            return ResultStatus.Failed;
        }
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        GetCustomersFromFile();
        return _customerList;
    }

    public Customer GetCustomer(string email)
    {
        GetCustomersFromFile();     
        try
        {
            var customer = _customerList.FirstOrDefault(c => c.Email == email);
            return customer ?? null!;
        }
        catch 
        {
            return null!;
        }
    }

    public ResultStatus DeleteCustomer(string email)
    {
        try
        {
            GetCustomersFromFile();
            var customer = GetCustomer(email);

            if (customer == null)
                return ResultStatus.NotFound;

            _customerList.Remove(customer);

            var json = JsonConvert.SerializeObject(_customerList, Formatting.Indented);
            var result = _fileService.SaveToFile(json);
            if (result)
                return ResultStatus.Success;

            return ResultStatus.SuccessWithErrors;
        }
        catch
        {
            return ResultStatus.Failed;
        }
    }

    public void GetCustomersFromFile()
    {
        try
        {
            var content = _fileService.GetFromFile();

            if (!string.IsNullOrEmpty(content))
                _customerList = JsonConvert.DeserializeObject<List<Customer>>(content)!;
        }
        catch { }
    }



}