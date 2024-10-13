namespace ConsoleApp.Models;

public class ResponseResult
{
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public object? Content { get; set; }
}
