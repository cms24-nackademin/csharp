string[] names = new string[3];

for (int i=0; i < names.Length; i++)
{
    Console.Write("Ange ett namn: ");
    names[i] = Console.ReadLine()!;
}

foreach (var name in names)
{
    Console.WriteLine($"Du angav namnet: {name}");
}

Console.ReadKey();
