using System.Text.RegularExpressions;

string firstName = "Hans Bengt Lennart".Trim();
string lastName = "Mattin-Lassei".Trim();
string streetName = " Nordkapsvägen 1".Trim();
string postalCode = "136 57".Trim();
string city = "Vega".Trim();

int age = 40;
var text_age = age.ToString();

string fullName = $"{firstName} {lastName}";
string address = $"{streetName}, {postalCode} {city}";
string greeting = $"Hej {fullName} som bor på {address} och är {age} år gammal.";

string email = $"{fullName}@domain.com";
email = Regex.Replace(email, @"\s+", ".");
email = Regex.Replace(email, "[åäÅÄ]", "a");
email = Regex.Replace(email, "[öÖ]", "o");
email = email.ToLower();

string userName = string.Concat(firstName.AsSpan(0, 3), lastName.AsSpan(0, 3));
userName = userName.ToLower();
userName = Regex.Replace(userName, "[åäÅÄ]", "a");
userName = Regex.Replace(userName, "[öÖ]", "o");

Console.WriteLine(greeting);
Console.WriteLine(email);
Console.WriteLine(userName);

Console.ReadKey();