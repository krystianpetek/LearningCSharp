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
        ShoppingCart shoppingCart = new()
        {
            Products = Models.Product.GetProducts()
        };

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
        ShoppingCart shoppingCart = new()
        {
            Products = Models.Product.GetProducts()
        };

        Product[] productArray =
        {
            new Product() { Name = "Kayak", Price = 275M },
            new Product() { Name = "Lifejacket", Price = 48.95M },
            new Product() { Name = "Soccer ball", Price = 19.50M },
            new Product() { Name = "Corner flag", Price = 34.95M }
        };
        
        decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
        
        return View("Index", new string[] { $"Array total: {arrayTotal:C2}" });
    }
}