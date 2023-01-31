using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;
public class FormController : Controller
{
    private readonly DataContext _dataContext;

    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index(long id = 1)
    {
        return View("Form",await _dataContext.Products.FindAsync(id));
    }

    [HttpPost]
    public IActionResult SubmitForm()
    {
        foreach(string key in Request.Form.Keys.Where(key => !key.StartsWith("_")))
        {
            TempData[key] = string.Join(", ", Request.Form[key]);
        }
        return RedirectToAction(nameof(Results));
    }

    public IActionResult Results()
    {
        return View();
    }
}
