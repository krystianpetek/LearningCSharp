using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;


public class HomeController : Controller
{
    private readonly DataContext _dataContext;
    public HomeController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index(long id = 1)
    {
        ViewBag.AveragePrice = await _dataContext.Products.AverageAsync(price => price.Price);

        Product? product = await _dataContext.Products.FindAsync(id);
        if(product.CategoryId == 1)
        {
            return View(
                viewName: "Watersports",
                model: product);
        }

        return View(product);
    }

    public async Task<IActionResult> SimpleIndex(long id = 1)
    {
        Product? product = await _dataContext.Products.FindAsync(id);
        return View(product);
    }

    public IActionResult Common()
    {
        return View();
    }

    public IActionResult List()
    {
        return View(_dataContext.Products);
    }

    public IActionResult ListBuildInTagHelpers()
    {
        return View(_dataContext.Products);
    }

    public IActionResult Html()
    {
        return View((object)"This is a <h3><i>string</i></h3>");
    }
}
