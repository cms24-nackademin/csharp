using ConsoleApp.Menus;

var cmi = new ContactMenuInteraction();


while (true)
{
    cmi.CreateContactPersonMenu();
    cmi.GetContactListMenu();
    Console.ReadKey();
}