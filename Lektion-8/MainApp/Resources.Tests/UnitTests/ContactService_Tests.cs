using Moq;
using Resources.Interfaces;
using Resources.Models;

namespace Resources.Tests.UnitTests;

public class ContactService_Tests
{
	private readonly Mock<IContactService<Contact, Contact>> _mockContactService = new();

	[Fact]
	public void Create__ShouldReturnSuccessResult__WhenContactIsCreated()
	{
		var contact = new Contact { FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };
		var expectedResponse = new ResultResponse<Contact> { Succeeded = true, Result = contact, Message = "Contact was created successfully" };

		_mockContactService.Setup(contactService => contactService.Create(contact)).Returns(expectedResponse);
		var contactService = _mockContactService.Object;

		// act
		var response = contactService.Create(contact);

		// assert
		Assert.True(response.Succeeded);
		Assert.Equal(contact, response.Result);
	}

	[Fact]
	public void GetAll__ShouldReturnListOfContacts()
	{
        var contact = new Contact { FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };
		var contacts = new List<Contact> { contact };
		var expectedResponse = new ResultResponse<IEnumerable<Contact>> { Succeeded = true, Result = contacts };

        _mockContactService.Setup(contactService => contactService.GetAll()).Returns(expectedResponse);
        var contactService = _mockContactService.Object;

		// act
		var response = contactService.GetAll();

		// assert
		Assert.True(response.Succeeded);
		Assert.Equal(contacts, response.Result);
    }

	[Fact]
	public void GetOne__ShouldReturnContact__WhenContactExitsInList()
	{
		var id = Guid.NewGuid().ToString();
        var contact = new Contact { Id = id, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };
        var expectedResponse = new ResultResponse<Contact> { Succeeded = true, Result = contact };

        _mockContactService.Setup(contactService => contactService.GetOne(id)).Returns(expectedResponse);
        var contactService = _mockContactService.Object;

        // act
        var response = contactService.GetOne(id);

        // assert
        Assert.True(response.Succeeded);
        Assert.Equal(contact, response.Result);
    }

	[Fact]
	public void Update__ShouldReturnUpdatedContact_WhenContactIsUpdated()
	{
        var id = Guid.NewGuid().ToString();
        var contact = new Contact { Id = id, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };
        var updatedContact = new Contact { Id = id, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans.mattin-lassei@domain.com" };
        var expectedResponse = new ResultResponse<Contact> { Succeeded = true, Result = updatedContact };

        _mockContactService.Setup(contactService => contactService.Update(id, updatedContact)).Returns(expectedResponse);
        var contactService = _mockContactService.Object;

        // act
        var response = contactService.Update(id, updatedContact);

        // assert
        Assert.True(response.Succeeded);
        Assert.NotEqual(contact, response.Result);
    }

	[Fact]
	public void Delete__ShouldReturnSuccessResult_WhenContactIsDeleted()
	{
        var id = Guid.NewGuid().ToString();
        var expectedResponse = new ResultResponse<Contact> { Succeeded = true };

        _mockContactService.Setup(contactService => contactService.Delete(id)).Returns(expectedResponse);
        var contactService = _mockContactService.Object;

		// act
		var response = contactService.Delete(id);

        // assert
        Assert.True(response.Succeeded);
    }
}
