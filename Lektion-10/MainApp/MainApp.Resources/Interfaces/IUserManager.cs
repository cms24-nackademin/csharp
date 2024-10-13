namespace MainApp.Resources.Interfaces;

public interface IUserManager<T> where T : IUser
{
    public void Create(T user);

    public IEnumerable<T> GetAll();

    public T Get(Func<T, bool> predicate);

    public T Update(Func<T, bool> predicate, T updated);

    public bool Delete(Func<T, bool> predicate);
}
