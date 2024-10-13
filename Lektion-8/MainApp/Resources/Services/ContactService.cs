using Newtonsoft.Json;
using Resources.Interfaces;
using Resources.Models;

namespace Resources.Services;

public class ContactService : IContactService<Contact,Contact>
{

    private readonly IFileService _fileService;
    private List<Contact> _contacts;

    public ContactService(string filePath)
    {
        _fileService = new FileService(filePath);
        _contacts = [];
        GetAll();
    }

       
    public ResultResponse<Contact> Create(Contact contact)
    {
        try
        {
            _contacts.Add(contact);

            var json = JsonConvert.SerializeObject(_contacts);
            var result = _fileService.SaveToFile(json);

            if (result.Succeeded)
                return new ResultResponse<Contact> { Succeeded = true };
            else
                return new ResultResponse<Contact> { Succeeded = false, Message = result.Message };

        }
        catch (Exception ex)
        {
            return new ResultResponse<Contact> { Succeeded = false, Message = ex.Message };
        }
    }

    // READ
    public ResultResponse<IEnumerable<Contact>> GetAll()
    {
        try
        {
            var result = _fileService.GetFromFile();

            if (result.Succeeded)
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(result.Result!)!;
                return new ResultResponse<IEnumerable<Contact>> { Succeeded = true, Result = _contacts };
            }           
            else
                return new ResultResponse<IEnumerable<Contact>> { Succeeded = false, Message = result.Message };

        }
        catch (Exception ex)
        {
            return new ResultResponse<IEnumerable<Contact>> { Succeeded = false, Message = ex.Message };
        }
    }

    public ResultResponse<Contact> GetOne(string id)
    {
        throw new NotImplementedException();
    }

    // UPDATE
    public ResultResponse<Contact> Update(string id, Contact updatedContact)
    {
        throw new NotImplementedException();
    }

    // DELETE
    public ResultResponse<Contact> Delete(string id)
    {
        throw new NotImplementedException();
    }
}
