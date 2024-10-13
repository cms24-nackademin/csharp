using Resources.Models;

namespace Resources.Interfaces;

public interface IContactService<T, TResult> where T : class where TResult : class
{
    ResultResponse<TResult> Create(T contact);
    ResultResponse<IEnumerable<TResult>> GetAll();
    ResultResponse<TResult> GetOne(string id);
    ResultResponse<TResult> Update(string id, T updatedContact);
    ResultResponse<TResult> Delete(string id);
}