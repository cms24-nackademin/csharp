string[] options = { "sten", "sax", "påse" };
Random rnd = new();

while (true)
{
    int computer_option = rnd.Next(0, 3);
    Console.WriteLine("Välj något av följande alternativ; sten(0), sax(1), påse(2)");
    Console.Write("Ditt val (0-2): ");
    int.TryParse(Console.ReadLine() ?? "-1", out int user_option);

    if (user_option < 0 || user_option > 2)
        Console.WriteLine("Du måste ange ett giltigt val. Försök igen.");
    else
    {
        Console.Clear();
        Console.WriteLine($"Du valde: {options[user_option]}");
        Console.WriteLine($"Datorn valde: {options[computer_option]}");
        Console.WriteLine("");

        if (user_option == computer_option)
            Console.WriteLine("Det blev oavgjort!");
        
        else if ((user_option == 0 && computer_option == 1) ||  (user_option == 1 && computer_option == 2) 
            || (user_option == 2 && computer_option == 0))
            Console.WriteLine("Grattis du vann!");

        else
            Console.WriteLine("Tyvärr, du förlorade!");
    }

    Console.ReadKey();
    Console.Clear();
}
