DateTime current = DateTime.Now;

var year = DateTime.Now.Year;
var month = DateTime.Now.Month;
var day = DateTime.Now.Day;

var today = DateTime.Today;
var date = DateTime.Now.ToString("yyyy-MM-dd");
var time = DateTime.Now.ToString("HH:mm");

Console.WriteLine($"Datum: {date}");
Console.WriteLine($"kl. {time}");
Console.ReadKey();