using MainApp.Models;

namespace MainApp.Interfaces;

public interface IUserService
{
	public ResponseResult AddUserToList(User user);
	public ResponseResult GetUsersFromList();
	public ResponseResult GetUserFromList(string email);
}
