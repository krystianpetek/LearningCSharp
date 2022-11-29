namespace SportsStore.Models;

public class CartLine
{
    public int CartLineId { get; init; }
    public Product? Product { get; init; }
    public int Quantity { get; set; }
}
