namespace ConsoleApp.Models;

public class ContactPerson
{
	public string Id { get; set; } = Guid.NewGuid().ToString();
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? PhoneNumber { get; set; }
	public Address? PostalAddress { get; set; }
}
