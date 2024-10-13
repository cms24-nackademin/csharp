namespace MainApp.Menus;

public class Menu
{
    private readonly CustomerMenu _customerMenu = new CustomerMenu();

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1.".PadRight(5) + "Create Customer");
        Console.WriteLine("2.".PadRight(5) + "View All Customers");
        Console.WriteLine("3.".PadRight(5) + "View Single Customer");
        Console.WriteLine("4.".PadRight(5) + "Delete Customer");
        Console.Write("\nEnter your choice: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                _customerMenu.CreateMenu();
                break;
            
            case "2":
                _customerMenu.ViewAllMenu();
                break;
            
            case "3":
                _customerMenu.ViewSingleMenu();
                break;
            
            case "4":
                _customerMenu.DeleteMenu();
                break;
            
            default:
                Console.WriteLine("\nIncorrect choice, please try again by pressing any key.");
                Console.ReadKey();
                break;
        }
    }
}
