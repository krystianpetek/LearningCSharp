namespace WebApp.Models;

public record Category
{
    public long CategoryId { get; init; }
    public string Name { get; init; } = string.Empty;
    public IEnumerable<Product>? Products { get; init; }
}