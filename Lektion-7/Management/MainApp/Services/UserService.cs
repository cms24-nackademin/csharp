using MainApp.Interfaces;
using MainApp.Models;
using Newtonsoft.Json;

namespace MainApp.Services;

public class UserService : IUserService
{
	private readonly List<User> _users = [];
	private readonly IFileService _fileService;

	public UserService(IFileService fileService)
	{
		_fileService = fileService;
	}

	public ResponseResult AddUserToList(User user)
	{
		try
		{
			if (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.Email))
			{
				if (!_users.Any(x => x.Email == user.Email))
				{
					_users.Add(user);
					
					var result = _fileService.SaveToFile(@"c:\files\users.json", JsonConvert.SerializeObject(_users));
					if (result.Succeeded)
					{
						return new ResponseResult { Succeeded = true };
					}
					else
					{
						return new ResponseResult { Succeeded = false, Message = "User list was not saved to file." };
					}
				}
				else
				{
					return new ResponseResult { Succeeded = false, Message = "User with same email already exists." };
				}
			}
			else
			{
				return new ResponseResult { Succeeded = false, Message = "Required values was not provided." };
			}

		}
		catch (Exception ex)
		{
			return new ResponseResult { Succeeded = false, Message = ex.Message };
		}

	}



	public ResponseResult GetUserFromList(string email)
	{
		try
		{
			User user = _users.FirstOrDefault(x => x.Email == email)!;
			if (user != null)
			{
				return new ResponseResult { Succeeded = true, Content = user };
			}
			else
			{
				return new ResponseResult { Succeeded = false, Message = "No user was found." };
			}

		}
		catch (Exception ex)
		{
			return new ResponseResult { Succeeded = false, Message = ex.Message };
		}
	}




	public ResponseResult GetUsersFromList()
	{
		try
		{
			return new ResponseResult
			{
				Succeeded = true,
				Content = _users
			};
		}
		catch (Exception ex)
		{
			return new ResponseResult { Succeeded = false, Message = ex.Message };
		}
	}
}
