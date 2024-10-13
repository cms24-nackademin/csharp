/*  
    while
    do while
    foreach
    for


    while (condition) {}
    ---------------------------------------------
    körs sålänge som tillståndet är sant.
    kontrollen sker direkt.
    kan vara farlig! (evighetsloop)

    int value = 1;

    while (value < 1)
    {
        Console.WriteLine(value);
        value++;
    }


    do {} while (condition);
    --------------------------------------------
    körs sålänge som tillståndet är sant
    kontrollen sker i slutet, vilket gör att loopen alltid körs minst 1 gång

    int value = 1;

    do
    {
        Console.WriteLine(value);
        value++;
    }
    while (value < 1);





    for (int i=0; condition; i++) {}
    -----------------------------------------------------------------------------
    loopar ett givet antal gånger.
    den har ett index (i) som den ökar eller minskar i++/i--
    

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"index = {i}");
    }

    string[] names = new string[5];
    names[0] = "Hans";
    names[1] = "Tommy";
    names[2] = "Joakim";
    names[3] = "Therese";
    names[4] = "Jeanette";

    for (int i=0; i < 3; i++)
    {
        Console.WriteLine(names[i]);
    }

    
    foreach (object in list) {}
    --------------------------------------------------
    string[] names = new string[5];
    names[0] = "Hans";
    names[1] = "Tommy";
    names[2] = "Joakim";
    names[3] = "Therese";
    names[4] = "Jeanette";

    foreach (string name in names) 
    {
        Console.WriteLine(name);
    }

*/

string[] names = new string[5];
names[0] = "Hans";
names[1] = "Tommy";
names[2] = "Joakim";
names[3] = "Therese";
names[4] = "Jeanette";

foreach (string name in names)
{
    Console.WriteLine(name);
}


Console.ReadKey();
