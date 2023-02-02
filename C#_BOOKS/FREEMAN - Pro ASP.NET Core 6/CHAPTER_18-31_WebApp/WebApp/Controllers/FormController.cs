using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers;
public class FormController : Controller
{
    private readonly DataContext _dataContext;

    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index([FromQuery] long? id)
    {
        ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name");
        return View("Form",
            await _dataContext.Products
            .Include(supplier => supplier.Supplier)
            .Include(category => category.Category)
            .FirstOrDefaultAsync(product => product.ProductId == id));
    }

    [HttpPost]
    public IActionResult SubmitForm(
        //string name, decimal price
        //Product product,
        [Bind(Prefix = "Category")] Category category,
        [Bind("Name","Category")] Product product
        )
    {
        TempData["name param"] = product.Name;
        TempData["price param"] = $"{product.Price}";
        TempData["product"] = JsonSerializer.Serialize(product);
        TempData["category"] = JsonSerializer.Serialize(category);
        foreach (string key in Request.Form.Keys /*.Where(key => !key.StartsWith("_"))*/ )
        {
            TempData[key] = string.Join(", ", Request.Form[key]);
        }
        return RedirectToAction(nameof(Results));
    }

    public IActionResult Results()
    {
        return View();
    }

    public string Header([FromHeader(Name = "Accept-Language")] string accept)
    {
        return $"Header: {accept}";
    }

    [IgnoreAntiforgeryToken]
    [HttpPost]
    public Product Body([FromBody] Product product)
    {
        return product;
    }
}
