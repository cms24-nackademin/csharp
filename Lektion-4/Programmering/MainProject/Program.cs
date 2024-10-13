using Shared.Models;
using Shared.Services;

var userService = new UserService();

userService.CreateUser(new UserCreateRequest { FirstName = "Hans" });

var users = userService.GetUsers();

users.Add(new User { FirstName = "sadfas" });