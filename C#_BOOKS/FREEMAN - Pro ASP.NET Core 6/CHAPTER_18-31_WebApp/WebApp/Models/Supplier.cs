namespace WebApp.Models;

public record Supplier
{
    public long SupplierId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public IEnumerable<Product>? Products { get; init; }
}
