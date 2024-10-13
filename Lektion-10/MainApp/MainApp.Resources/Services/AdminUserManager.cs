using MainApp.Resources.Interfaces;

namespace MainApp.Resources.Services;

public class AdminUserManager : BaseService<IAdminUser>
{
    public override void Create(IAdminUser user)
    {
        if (!_users.Any(u => u.Email == user.Email))
        {
            user.Id = Guid.NewGuid().ToString();
            user.Created = DateTime.Now;

            if (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
                _users.Add(user);
        }
    }

    public override IEnumerable<IAdminUser> GetAll()
    {
        return base.GetAll().OrderByDescending(x => x.Created);
    }

    public override IAdminUser Update(Func<IAdminUser, bool> predicate, IAdminUser updated)
    {
        var user = _users.FirstOrDefault(predicate);
        if (user != null)
        {
            user = updated;
        }

        return user!;
    }
}
