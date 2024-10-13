using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace Resources.Tests;

public class CustomerServiceTests
{
    [Fact]
    public void AddToList_ShouldReturnSuccess_WhenCustomerAddedToList()
    {
        // arrange
        Customer customer = new Customer { Name = "Hans", Email = "hans@domain.com", Phone = "073-123 12 12" };
        CustomerService customerService = new CustomerService();

        // act
        ResultStatus result = customerService.AddToList(customer);
        var customerList = customerService.GetAllCustomers();

        // assert
        Assert.Equal(ResultStatus.Success, result);
        Assert.Single(customerList);
    }
}
