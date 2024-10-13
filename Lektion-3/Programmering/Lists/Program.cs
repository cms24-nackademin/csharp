/*   
    List<string> names = new List<string>();
    var names = new List<string>();
    List<string> names = new();
    List<string> names = []; 
*/

List<string> names = [];

names.Add("Hans");
names.Add("Tommy");
names.Add("Anki");
names.Add("Hans");

//names.ForEach(name => Console.WriteLine(name));
//Console.ReadKey();

//names.Sort();
//names.ForEach(name => Console.WriteLine(name));
//Console.ReadKey();

//names.Reverse();
//names.ForEach(name => Console.WriteLine(name));
//Console.ReadKey();

//Console.WriteLine(names.Count);
//Console.ReadKey();

//Console.WriteLine(names.Any());
//Console.ReadKey();

//Console.WriteLine(names.Any(name => name == "Amanda"));
//Console.ReadKey();

//names.Remove("Hans");
//names.ForEach(name => Console.WriteLine(name));
//Console.ReadKey();

//names.RemoveAll(name => name == "Hans");
//names.ForEach(name => Console.WriteLine(name));
//Console.ReadKey();

var name = names.FirstOrDefault(name => name == "Hans");
Console.WriteLine(name);
Console.ReadKey();