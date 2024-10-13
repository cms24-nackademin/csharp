using MainApp.Resources.Interfaces;

namespace MainApp.Resources.Models;

public class AdminUser : IAdminUser
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime Created { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string RoleName { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string OrganizationalNumber { get; set; } = null!;

    public string Signature()
    {
        return $"{FirstName} {LastName} <{Email}>\n{CompanyName}, {RoleName}";
    }
}