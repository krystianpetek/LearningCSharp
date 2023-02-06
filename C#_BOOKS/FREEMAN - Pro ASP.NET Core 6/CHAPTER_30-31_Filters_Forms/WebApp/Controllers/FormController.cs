using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

[AutoValidateAntiforgeryToken]
public class FormController : Controller
{
    private readonly DataContext _dataContext;
    private IEnumerable<Category> _categories => _dataContext.Categories;
    private IEnumerable<Supplier> _suppliers => _dataContext.Suppliers;

    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IActionResult Index()
    {
        return View(_dataContext.Products
            .Include(product => product.Category)
            .Include(product => product.Supplier));
    }
}
