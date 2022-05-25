using LAB1MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB1MVC.Controllers
{
    public class ProductsController : Controller
    {
        public List<Product> products;
        public ProductsController(List<Product> products)
        {
            this.products = products;
        }

        public IActionResult Index()
        {
            products.Add(new Product()
            {
                ProductName = "Chleb żytni", ProductDescription = "Chleb żytni bez drożdzy", ProductPrice = (2.99M), ProductId = 1
            });
            products.Add(new Product()
            {
                ProductName = "Chleb żytni", ProductDescription = "Chleb żytni bez drożdzy", ProductPrice = (2.99M), ProductId = 2
            });
            return View(products);
        }
    }
}
