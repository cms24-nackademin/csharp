using Classes.Models;

namespace Classes.Services;

internal class MenuService
{
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Lägg till ny kontakt");
        Console.WriteLine("2. Lista alla kontaker");
        Console.WriteLine("3. Ta bort en kontakt");
        Console.WriteLine("0. Avsluta");
        Console.Write("Ange ett menyalternativ: ");
        int.TryParse(Console.ReadLine()!, out int option);

        switch(option)
        {
            case 0:
                Environment.Exit(0);
                break;

            case 1:
                AddContact();
                break;

            case 2:
                break;

            case 3:
                break;

            default:
                Console.WriteLine("Du måste ange ett giltigt menyalternativ.");
                break;
        }

    }

    public void AddContact()
    {
        Console.Clear();
        Contact contact = new();

        Console.Write("Ange förnamn: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Ange efternamn: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Ange e-postadress: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Ange telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!;
    }
}
