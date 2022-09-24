namespace LanguageFeatures.Models;

public static class MyExtensionMethod
{
    public static decimal TotalPrices(this IEnumerable<Product?> products)
    {
        decimal totalPrice = 0;
        foreach (Product? product in products)
        {
            totalPrice += product?.Price ?? 0;
        }
        return totalPrice;
    }

    public static IEnumerable<Product?> FilterByPrice(this IEnumerable<Product?> products, decimal minimumPrice)
    {
        foreach (Product? product in products)
        {
            if ((product?.Price ?? 0) >= minimumPrice)
                yield return product;
        }
    }
}