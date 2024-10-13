namespace MainApp.Resources.Services;

public abstract class BaseService<T> where T : class
{
    public List<T> _users { get; set; } = [];

    public abstract void Create(T user);

    public virtual bool Delete(Func<T, bool> predicate)
    {
        var user = _users.FirstOrDefault(predicate);
        if (user != null)
        {
            _users.Remove(user);
            return true;
        }

        return false;
    }

    public virtual T Get(Func<T, bool> predicate)
    {
        var user = _users.FirstOrDefault(predicate);
        if (user != null)
            return user;

        return default!;
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _users;
    }

    public abstract T Update(Func<T, bool> predicate, T updated);
}
