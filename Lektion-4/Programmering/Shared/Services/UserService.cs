using Shared.Models;

namespace Shared.Services;

public class UserService
{
    private readonly List<User> _users = [];


    public void CreateUser(UserCreateRequest request)
    {
        var exists = _users.Any(user => user.FirstName == request.FirstName);

        if (!exists)
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName!.Trim(),
                LastName = request.LastName!.Trim(),
                Email = request.Email!.Trim().ToLower(),
                Created = DateTime.Now,
                Modified = DateTime.Now
            };

            _users.Add(user);
        }
    }

    public IEnumerable<User> GetUsers()
    {
        return _users;
    }
}
