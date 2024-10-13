using MainApp.Resources.Services;

var adminUserManager = new AdminUserManager();

adminUserManager.Get(x => x.Id == "hans@domain.com");

Console.ReadKey();