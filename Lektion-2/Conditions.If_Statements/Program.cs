bool overheating = false;
int temperature = 100;


if (temperature > 40)
{
    overheating = true;
}
else
{
    overheating = false;
}


overheating = (temperature > 40) ? true : false;


if(temperature > 40)
{
    overheating = true;
}


if (temperature > 40)
{
    overheating = true;
    Console.WriteLine("Överhettad");
}
else
    overheating = true;


Console.ReadKey();

