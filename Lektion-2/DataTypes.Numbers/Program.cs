/*  
    DATA TYPES for Numbers
    ------------------------------------------------------------------------------------
    byte    8-bitars heltal
    sbyte   8-bitars heltal
    short   16-bitars heltal
    ushort  16-bitars heltal
    int     32-bitars heltal   
    uint    32-bitars heltal
    long    64-bitars heltal
    ulong   64-bitars heltal

    float   32-bitars flyttal
    double  64-bitars flyttal
    decimal 128-bitars flyttal
 



    Console.WriteLine("int (min-value): " + int.MinValue);
    Console.WriteLine("int (max-value): " + int.MaxValue);
    Console.WriteLine("uint (min-value): " + uint.MinValue);
    Console.WriteLine("uint (max-value): " + uint.MaxValue);

    Console.WriteLine("long (min-value): " + long.MinValue);
    Console.WriteLine("long (max-value): " + long.MaxValue);
    Console.WriteLine("ulong (min-value): " + ulong.MinValue);
    Console.WriteLine("ulong (max-value): " + ulong.MaxValue);

    Console.WriteLine("short (min-value): " + short.MinValue);
    Console.WriteLine("short (max-value): " + short.MaxValue);
    Console.WriteLine("ushort (min-value): " + ushort.MinValue);
    Console.WriteLine("ushort (max-value): " + ushort.MaxValue);

    Console.WriteLine("sbyte (min-value): " + sbyte.MinValue);
    Console.WriteLine("sbyte (max-value): " + sbyte.MaxValue);
    Console.WriteLine("byte (min-value): " + byte.MinValue);
    Console.WriteLine("byte (max-value): " + byte.MaxValue);
*/

int age = 40;

string text_age = "40";
age = int.Parse(text_age);
int.TryParse(text_age, out age);
age = Convert.ToInt32(text_age);


float f_value = 0.1f;
double value = 0.1;
decimal d_value = 0.1m;



var sum = 1000000000.12345678901234567890123456789;

Console.WriteLine(sum);
Console.ReadKey();