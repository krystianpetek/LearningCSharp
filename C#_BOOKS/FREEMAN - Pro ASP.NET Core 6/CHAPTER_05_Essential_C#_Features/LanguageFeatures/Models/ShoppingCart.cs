using System.Collections;
using LanguageFeatures.Interfaces;

namespace LanguageFeatures.Models;

public class ShoppingCart : IEnumerable<Product?>, IProductSelection
{
    private List<Product> _products = new();

    public ShoppingCart(params Product[] prods)
    {
        _products.AddRange(prods);
    }

    public IEnumerable<Product>? Products
    {
        get => _products;
    }

    public IEnumerator<Product?> GetEnumerator() =>
        Products?.GetEnumerator() ?? Enumerable.Empty<Product?>().GetEnumerator();
        
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}