using MainApp.Models;

namespace MainApp.Interfaces;

public interface IFileService
{
	public ResponseResult SaveToFile(string filePath, string content);
	public ResponseResult GetFromFile(string filePath);
}
