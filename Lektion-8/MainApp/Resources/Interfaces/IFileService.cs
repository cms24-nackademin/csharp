using Resources.Models;

namespace Resources.Interfaces;

public interface IFileService
{
    public ResultResponse<string> SaveToFile(string content);
    public ResultResponse<string> GetFromFile();
}
