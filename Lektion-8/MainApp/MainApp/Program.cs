using Resources.Interfaces;
using Resources.Models;
using Resources.Services;

IContactService<Contact, Contact> contactService = new ContactService(@"c:\projects\contacts.json");

var contact = new Contact 
{ 
    FirstName = "Hans", 
    LastName = "Mattin-Lassei", 
    Email = "hans@domain.com", 
    Phone = "073-123 45 67" 
};


var response = contactService.Create(contact);
if (response.Succeeded)
    Console.WriteLine("Contact created successfully.");
else
    Console.WriteLine("Something went wrong. No contact was created.");

Console.ReadKey();