using MainApp.Models;

namespace MainApp.Services;

internal static class MenuService
{
    private static readonly UserService _userService = new UserService();


    private static void CreateUserMenu()
    {
        var user = new User();

        Console.Clear();
        Console.WriteLine("-- CREATE NEW USER --");
        
        Console.Write("Enter first name: ");
        user.FirstName = Console.ReadLine() ?? "";

        Console.Write("Enter last name: ");
        user.LastName = Console.ReadLine() ?? "";

        Console.Write("Enter e-mail address: ");
        user.Email = Console.ReadLine() ?? "";

        Console.Write("Enter phone number: ");
        user.PhoneNumber = Console.ReadLine() ?? "";

        var response = _userService.CreateUser(user);
        Console.WriteLine(response.Message);
    }



    private static void ListAllUsersMenu()
    {
        Console.Clear();
        Console.WriteLine("-- USER LIST --");

        var users = _userService.GetAllUsers();
        if (users != null)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} <{user.Email}>");
            }
        }
        else
        {
            Console.WriteLine("No users was found.");
        }
    }

    private static void ExitApplicationMenu()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n)");
        var answer = Console.ReadLine() ?? "n";
        if (answer.ToLower() == "y")
            Environment.Exit(0);
    }

    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Create New User");
        Console.WriteLine("2. List All Users");
        Console.WriteLine("0. Exit");

        Console.Write("Enter an option: ");

        if (int.TryParse(Console.ReadLine(), out int option))
        {
            switch (option)
            {
                case 1:
                    CreateUserMenu();
                    Console.ReadKey();
                    break;

                case 2:
                    ListAllUsersMenu();
                    Console.ReadKey();
                    break;

                case 0:
                    ExitApplicationMenu();
                    break;

                default:
                    Console.WriteLine("Invalid option selected");
                    Console.ReadKey();
                    break;
            }
        }
    }

}
