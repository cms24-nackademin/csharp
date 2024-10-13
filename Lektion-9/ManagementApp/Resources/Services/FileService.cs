namespace Resources.Services;

public class FileService(string filePath)
{
    private readonly string _filePath = filePath;

    public bool SaveToFile(string content)
    {
        try
        {
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(content);
            return true;
        }
        catch 
        {
            return false;
        }
    }


    public string GetFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                var content = sr.ReadToEnd();
                return content;
            }
        }
        catch { }

        return null!;
    }
}