Console.WriteLine("Välkommen till detta lilla program.");
Console.Write("Vill du lägga till informtion om dig själv? (y/n): ");
string answer = Console.ReadLine() ?? "";

if (answer.ToLower() == "y")
{
    Console.Write("Ange förnamn: ");
    string firstName = Console.ReadLine() ?? "";

    Console.Write("Ange efternamn: ");
    string lastName = Console.ReadLine() ?? "";

    Console.WriteLine($"Hejsan {firstName} {lastName}");
}

Console.WriteLine("Tack och hej!");
Console.ReadKey();