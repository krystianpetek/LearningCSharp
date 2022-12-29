using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public record Product
{
    public long ProductId { get; init; }
    public string Name { get; init; } = string.Empty;
    [Column(TypeName = "decimal(8,2)")]
    public decimal Price { get; init; }
    public long CategoryId { get; init; }
    public Category? Category { get; init; }
    public long SupplierId { get; init; }
    public Supplier? Supplier { get; init; }
}
