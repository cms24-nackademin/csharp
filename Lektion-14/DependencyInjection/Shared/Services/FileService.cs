namespace Shared.Services;

public class FileService(string filePath)
{
    private readonly string _filePath = filePath;

    public void SaveToFile(string content)
    {
        using var sw = new StreamWriter(_filePath);
        sw.WriteLine(content);
    }

    public string ReadFromFile()
    {
        if (File.Exists(_filePath))
        {
            using var sr = new StreamReader(_filePath);
            return sr.ReadToEnd();
        }
        return null!;
    }
}
