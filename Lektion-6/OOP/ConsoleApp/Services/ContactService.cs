using ConsoleApp.Models;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class ContactService
{
    private readonly  List<ContactPerson> _contacts  = [];


    public ResponseResult AddContactToList(ContactPerson contactPerson)
    {
        try
        {
            if (!_contacts.Any(cp => cp.Email == contactPerson.Email))
            {
                _contacts.Add(contactPerson);
                return new ResponseResult { Succeeded = true, Message = "Contact Person was added successfully."};
            }

            return new ResponseResult { Succeeded = false, Message = "A contact person with the same email already exists." };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
            return new ResponseResult { Succeeded = false, Message = "Something went wrong! Contact person was not added to the list" };
        }

    }



    public ResponseResult GetContactList()
    {
        return new ResponseResult
        {
            Succeeded = true,
            Content = _contacts
        };
    }
}
