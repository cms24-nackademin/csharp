using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Menus;

internal class ContactMenuInteraction
{
    private readonly ContactService _contactService = new ContactService();


    public void CreateContactPersonMenu()
    {
        var contactPerson = new ContactPerson
        {
            PostalAddress = new Address()
        };

        Console.Write("First Name: ");
        contactPerson.FirstName = Console.ReadLine();

        Console.Write("Last Name: ");
        contactPerson.LastName = Console.ReadLine();

        Console.Write("Email Address: ");
        contactPerson.Email = Console.ReadLine();

        Console.Write("Phone Number: ");
        contactPerson.PhoneNumber = Console.ReadLine();


        Console.Write("Street Name: ");
        contactPerson.PostalAddress!.StreetName = Console.ReadLine();

        Console.Write("PostalCode: ");
        contactPerson.PostalAddress!.PostalCode = Console.ReadLine();

        Console.Write("City: ");
        contactPerson.PostalAddress!.City = Console.ReadLine();

        var result = _contactService.AddContactToList(contactPerson);
        if (result.Succeeded)
        {
            Console.WriteLine($"{result.Message}");
        }
        else
        {
            Console.WriteLine($"{result.Message}");
        }


    }

    public void GetContactListMenu()
    {
        var result = _contactService.GetContactList();

        foreach( var contactPerson in result.Content as IEnumerable<ContactPerson>)
        {
            Console.WriteLine($"{contactPerson.FirstName} {contactPerson.LastName}");
        }
    }


}
