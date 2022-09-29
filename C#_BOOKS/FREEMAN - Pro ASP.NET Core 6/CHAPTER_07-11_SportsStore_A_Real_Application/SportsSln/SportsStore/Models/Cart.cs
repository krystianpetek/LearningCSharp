namespace SportsStore.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; } = new();

    public void AddItem(Product product, int quantity)
    {
        var line = Lines.FirstOrDefault(x => x.Product?.ProductId == product.ProductId);

        if (line == null)
        {
            Lines.Add(new CartLine()
            {
                Product = product,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public void RemoveItem(Product product)
    {
        Lines.RemoveAll(l => l.Product?.ProductId == product.ProductId);
    }

    public decimal ComputeTotalValue()
    {
        return Lines.Sum(e => e.Product.Price * e.Quantity);
    }

    public void Clear() => Lines.Clear();
}
public class CartLine
{
    public int CartLineId { get; init; }
    public Product? Product { get; init; }
    public int Quantity { get; set; }
}
