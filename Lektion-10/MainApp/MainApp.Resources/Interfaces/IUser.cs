namespace MainApp.Resources.Interfaces;

public interface IUser
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Created { get; set; }

    public string Signature();
}
