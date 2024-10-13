using MainApp.Models;
using System.Diagnostics;

namespace MainApp.Services;

public class UserService
{
    private List<User> _users = [];

    public ServiceResponse CreateUser(User user)
    {
        try
        { 
            if (string.IsNullOrEmpty(user.Email))
                return new ServiceResponse { Succeeded = false, Message = "No e-mail address was provided." };


            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
                return new ServiceResponse { Succeeded = false, Message = "First name and last name must be provided." };


            if (_users.Any(x => x.Email == user.Email))
                return new ServiceResponse { Succeeded = false, Message = "User with the same email address already exists." };

            _users.Add(user);
            return new ServiceResponse { Succeeded = true, Message = "User was created." };

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceResponse { Succeeded = false, Message = ex.Message };
        }

    }

    public IEnumerable<User> GetAllUsers()
    {
        try
        {
            return _users;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }

    public User GetUser(string email)
    {
        try
        {
            var user = _users.FirstOrDefault(x => x.Email == email);
            if (user != null)
                return user;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }

}
