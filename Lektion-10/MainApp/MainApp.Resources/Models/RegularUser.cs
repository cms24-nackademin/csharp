using MainApp.Resources.Interfaces;

namespace MainApp.Resources.Models;

public class RegularUser : IRegularUser
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime Created { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public string Signature()
    {
        return $"{FirstName} {LastName} <{Email}>";
    }
}
