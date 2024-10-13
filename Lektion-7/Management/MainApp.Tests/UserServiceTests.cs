using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Services;
using Moq;

namespace MainApp.Tests;

public class UserServiceTests
{
	#region AddUserToList

	[Fact]
	public void AddUserToList__ShouldAddUserToListOfUsers__ReturnResponseResultSucceeded_True()
	{
		// Arrange - förberedelser
		Mock<IFileService> fileServiceMock = new Mock<IFileService>();
		fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new ResponseResult { Succeeded = true });

		IUserService userService = new UserService(fileServiceMock.Object);
		User user = new User() { FirstName = "Hans", LastName = "ML", Email = "hans@domain.com" };


		// Act - utförandet
		ResponseResult result = userService.AddUserToList(user);

		// Assert - Utvärdering av resultatet
		Assert.NotNull(result);
		Assert.True(result.Succeeded);

	}

	[Theory]
	[InlineData("","","")]
	[InlineData("Hans", "", "")]
	[InlineData("Hans", "Mattin-Lassei", "")]
	[InlineData("Hans", "", "hans@domain.com")]
	[InlineData("", "Mattin-Lassei", "hans@domain.com")]
	public void AddUserToList__ShouldNotAddUserToListWhenPropertiesAreEmpty__ReturnResponseResultSucceeded_False(string firstName, string lastName, string email)
	{
		// Arrange - förberedelser
		Mock<IFileService> fileServiceMock = new Mock<IFileService>();
		fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new ResponseResult { Succeeded = true });

		IUserService userService = new UserService(fileServiceMock.Object);
		User user = new User() { FirstName = firstName, LastName = lastName, Email = email };


		// Act - utförandet
		ResponseResult result = userService.AddUserToList(user);


		// Assert - Utvärdering av resultatet
		Assert.NotNull(result);
		Assert.False(result.Succeeded);

	}

	[Fact]
	public void AddUserToList__ShouldNotAddToListIfUserEmailAlreadyExists__ReturnResponseResultSucceeded_False()
	{
		// Arrange - förberedelser
		Mock<IFileService> fileServiceMock = new Mock<IFileService>();
		fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new ResponseResult { Succeeded = true });

		IUserService userService = new UserService(fileServiceMock.Object);
		User user = new User() { FirstName = "Hans", LastName = "ML", Email = "hans@domain.com" };
		userService.AddUserToList(user);


		// Act - utförandet
		ResponseResult result = userService.AddUserToList(user);

		// Assert - Utvärdering av resultatet
		Assert.NotNull(result);
		Assert.False(result.Succeeded);
		Assert.Equal("User with same email already exists.", result.Message);
	}

	#endregion

	#region GetUsersFromList

	[Fact]
	public void GetUsersFromList__ShouldGetAllUsers__ReturnResponseResultWithContent_List()
	{
		// Arrange
		User user = new User() { FirstName = "Hans", LastName = "ML", Email = "hans@domain.com" };
		Mock<IFileService> fileServiceMock = new Mock<IFileService>();
		fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new ResponseResult { Succeeded = true });

		IUserService userService = new UserService(fileServiceMock.Object);
		userService.AddUserToList(user);

		// Act
		ResponseResult result = userService.GetUsersFromList();

		// Asset
		Assert.NotNull(result);
		Assert.True(result.Succeeded);
		Assert.Single((List<User>)result.Content!);

	}

	#endregion

	#region GetUserFromList

	[Fact]
	public void GetUserFromList__ShouldGetUserFromList__ReturnResponseResultWithContent_User()
	{
		// Arrange
		User user = new User() { FirstName = "Hans", LastName = "ML", Email = "hans@domain.com" };
		Mock<IFileService> fileServiceMock = new Mock<IFileService>();
		fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new ResponseResult { Succeeded = true });

		IUserService userService = new UserService(fileServiceMock.Object);
		userService.AddUserToList(user);

		// Act
		ResponseResult result = userService.GetUserFromList(user.Email);

		// Assert
		Assert.NotNull(result);
		Assert.True(result.Succeeded);
		Assert.Equal(user.Email, ((User)result.Content!).Email);
	}

	[Fact]
	public void GetUserFromList__ShouldNotGetUserFromListWhenNotFound__ReturnResponseResult_False()
	{
		// Arrange
		User user = new User() { FirstName = "Hans", LastName = "ML", Email = "hans@domain.com" };
		Mock<IFileService> fileServiceMock = new Mock<IFileService>();
		fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new ResponseResult { Succeeded = true });

		IUserService userService = new UserService(fileServiceMock.Object);


		// Act
		ResponseResult result = userService.GetUserFromList(user.Email);

		// Assert
		Assert.NotNull(result);
		Assert.False(result.Succeeded);
		Assert.Equal("No user was found.", result.Message);
	}

	#endregion

}
