bool closeApp = true;

do
{
    Console.Clear();
    Console.WriteLine("Menu Options");
    Console.WriteLine("1. Add New Member");
    Console.WriteLine("2. Remove Member");
    Console.WriteLine("3. View Members");
    Console.WriteLine("0. Exit Application");

    Console.Write("Enter your choose: ");
    var option = Console.ReadLine();

    switch (option.ToLower())
    {
        case "1":
            break;

        case "2":
            break;

        case "3":
            break;

        case "0":
            closeApp = true;
            break;

        default:
            Console.WriteLine("You must enter a valid option.");
            Console.ReadKey();
            break;
    }

}
while (!closeApp);
