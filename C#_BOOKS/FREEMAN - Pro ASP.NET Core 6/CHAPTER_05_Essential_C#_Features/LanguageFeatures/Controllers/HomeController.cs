using LanguageFeatures.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers;

public class HomeController : Controller
{
    public ViewResult Index() => View(new string[] { "C#", "Language", "Features" });

    public ViewResult Product()
    {
        Product?[] products = Models.Product.GetProducts();
        // return View("Index",new string[] { products[0].Name });
        // return View("Index", new string[] { products[0]!.Name });
        // return View("Index", new string[] { products[0]?.Name ?? "No value" });
        return View("Index", new string[] { $"Name: {products[0]?.Name}, Price: {products[0]?.Price:C2} " });
    }

    public ViewResult Names()
    {
        // string[] names = new string[3];
        // names[0] = "Bob";
        // names[1] = "Joe";
        // names[2] = "Alice";
        // return View("Names",names);
        return View("Index", new string[] { "Bob", "Joe", "Alice" });
    }

    public ViewResult Dictionary()
    {
        // Dictionary<string, Product> products = new()
        // {
        //     { "Kayak", new Product() { Name = "Kayak", Price = 275M } },
        //     { "Lifejacket", new Product() { Name = "Lifejacket", Price = 48.95M } }
        // };

        Dictionary<string, Product> products = new()
        {
            ["Kayak"] = new Product() { Name = "Kayak", Price = 275M },
            ["Lifejacket"] = new Product() { Name = "Lifejacket", Price = 48.95M }
        };

        return View("Index", products.Keys);
    }

    public ViewResult PatternMatching()
    {
        object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
        decimal total = 0;
        for (int i = 0; i < data.Length; i++)
        {
            // if(data[i] is decimal d)
            // {
            //     total += d;
            // }

            switch (data[i]) // pattern matching in switch
            {
                case decimal decimalValue:
                    total += decimalValue;
                    break;
                case int intValue when intValue > 50:
                    total += intValue;
                    break;
            }
        }

        return View("Index", new string[] { $"Total: {total:C2}" });
    }

    public ViewResult ShoppingCart()
    {
        IProductSelection shoppingCart = new ShoppingCart(Models.Product.GetProducts()!);

        Product[] productArray =
        {
            new Product() { Name = "Kayak", Price = 275M },
            new Product() { Name = "Lifejacket", Price = 48.95M }
        };

        decimal cartTotal = shoppingCart.TotalPrices();
        decimal arrayTotal = productArray.TotalPrices();

        return View("Index", new string[] { $"Cart total: {cartTotal:C2}", $"Array total: {arrayTotal:C2}" });
    }

    public ViewResult FilterShoppingCart()
    {

        bool FilterByPrice(Product? p) => (p?.Price ?? 0) >= 20;

        Func<Product?, bool> FilterByName = delegate(Product? product) { return product?.Name?[0] == 'S'; };

        IProductSelection shoppingCart = new ShoppingCart(Models.Product.GetProducts()!);

        Product[] productArray =
        {
            new Product() { Name = "Kayak", Price = 275M },
            new Product() { Name = "Lifejacket", Price = 48.95M },
            new Product() { Name = "Soccer ball", Price = 19.50M },
            new Product() { Name = "Corner flag", Price = 34.95M }
        };

        decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
        decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

        decimal priceGenericFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
        decimal nameGenericFilterTotal = productArray.Filter(FilterByName).TotalPrices();
        // or lambda expression
        priceGenericFilterTotal = productArray.Filter(product => (product?.Price ?? 0) > 20).TotalPrices();
        nameGenericFilterTotal = productArray.Filter(product => product?.Name[0] == 'S').TotalPrices();


        return View("Index", new string[]
        {
            $"Price total: {priceFilterTotal:C2}",
            $"Name total: {nameFilterTotal:C2}",
            $"Price generic filter total: {priceGenericFilterTotal:C2}",
            $"Name generic filter total: {nameGenericFilterTotal:C2}"
        });
    }

    public ViewResult LambdaMethod() => View("Index", Models.Product.GetProducts().Select(product => product?.Name));

    public ViewResult AnonymousTypes()
    {
        var products = new[]
        {
            new { Name = "Kayak", Price = 275M },
            new { Name = "Lifejacket", Price = 48.95M },
            new { Name = "Soccer ball", Price = 19.50M },
            new { Name = "Corner flag", Price = 34.95M },
        };

        return View("Index", products.Select(product => product.Name));
    }

    public ViewResult DefaultImplementation()
    {
        IProductSelection cart = new ShoppingCart(
            new Product() { Name = "Kayak", Price = 275M },
            new Product() { Name = "Lifejacket", Price = 48.95M },
            new Product() { Name = "Soccer ball", Price = 19.50M },
            new Product() { Name = "Corner flag", Price = 34.95M }
        );
        //return View("Index",cart.Products?.Select(p => p.Name));
        //or
        return View("Index",cart.Names);
    }

    public async Task<ViewResult> AsynchronousPageLength()
    {
        long? length = await MyAsyncMethods.GetPageLengthAsync();
        return View("Index",new string[] {$"Length: {length}"});
    }

    public async Task<ViewResult> AsynchronousPageLengths()
    {
        List<string> output = new();
        foreach (long? len in await MyAsyncMethods.GetPageLengthsAsync(output, "apress.com", "microsoft.com",
                     "amazon.com"))
        {
            output.Add($"Page length: {len}");
        }

        return View("Index", output);
    }

    public ViewResult GettingNames()
    {
        var products = new[]
        {
            new { Name = "Kayak", Price = 275M },
            new { Name = "Lifejacket", Price = 48.95M },
            new { Name = "Soccer ball", Price = 19.50M },
            new { Name = "Corner flag", Price = 34.95M },
        };

        return View("Index", products.Select(product => $"{nameof(product.Name)}: {product.Name}, {nameof(product.Price)}: {product.Price}"));
    }
}