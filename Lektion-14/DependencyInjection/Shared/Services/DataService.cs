using Newtonsoft.Json;

namespace Shared.Services;

public class DataService<T>(FileService fileService)
{
    private readonly FileService _fileService = fileService;
    private List<T> _list = [];

    public void AddToList(T item)
    {
        _list.Add(item);
        _fileService.SaveToFile(JsonConvert.SerializeObject(_list));
    }

    public IEnumerable<T> GetAll()
    {
        var content = _fileService.ReadFromFile();
        _list = JsonConvert.DeserializeObject<List<T>>(content)!;

        return _list;
    }
}
