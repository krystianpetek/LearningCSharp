namespace BlazorServerApp.Models;

public class TodoItem
{
    private static int _id = 1;
    public TodoItem()
    {
        Id = _id;
        _id++;
    }

    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
