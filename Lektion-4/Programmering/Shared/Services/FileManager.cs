namespace Shared.Services;

public class FileManager
{
    private readonly string? _filePath;

    public FileManager(string filePath)
    {
        _filePath = filePath;
    }

}
