namespace ConsoleApp.Models;

public class Address
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
}
