using Resources.Interfaces;
using Resources.Models;

namespace Resources.Services;

public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;



    public ResultResponse<string> GetFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("File not found.");

            using var sr = new StreamReader(_filePath);
            var content = sr.ReadToEnd();

            return new ResultResponse<string> { Succeeded = true, Result = content };
        }
        catch (Exception ex)
        {
            return new ResultResponse<string> { Succeeded = false, Message = ex.Message };
        }
    }



    public ResultResponse<string> SaveToFile(string content)
    {
        try
        {
            using var sw = new StreamWriter(_filePath, false);
            sw.WriteLine(content);

            return new ResultResponse<string> { Succeeded = true };
        }
        catch (Exception ex)
        {
            return new ResultResponse<string> { Succeeded = false, Message = ex.Message };
        }
    }
}
