namespace TodoApp_Advanced.Shared.Models;

public class ActivityItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Activity { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
}
