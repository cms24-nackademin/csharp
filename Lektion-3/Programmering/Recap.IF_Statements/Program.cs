Console.Write("Ange din ålder: ");
bool succeeded = int.TryParse(Console.ReadLine(), out int age);

if (succeeded)
{
    if (((age >= 18) && (age < 50)) || ((age >= 18) && (age < 40)))
    {
        Console.WriteLine("Du har åldern inne.");
    }
    else
    {
        Console.WriteLine("Du är inte myndig.");
    }
}
else
{
    Console.WriteLine("Du måste ange en giltig ålder i siffror.");
}


