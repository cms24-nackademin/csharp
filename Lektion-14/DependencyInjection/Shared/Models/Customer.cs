namespace Shared.Models;

public class Customer
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DisplayName => $"{Name} <{Email}>";
}