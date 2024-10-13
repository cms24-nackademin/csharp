namespace Shared.Models;

public class User
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public bool IsAuthorized { get; set; }
}
