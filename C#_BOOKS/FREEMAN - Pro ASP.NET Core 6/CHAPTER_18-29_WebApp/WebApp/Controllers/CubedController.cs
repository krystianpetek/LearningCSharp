using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CubedController : Controller
{
    public IActionResult Index()
    {
        return View("Cubed");
    }

    public IActionResult Cube(double num)
    {
        //TempData["value"] = $"{num}";
        Value = $"{num}";

        //TempData["result"] = $"{Math.Pow(num,3)}";
        Result = $"{Math.Pow(num,3)}";

        return RedirectToAction(nameof(Index));
    }

    [TempData]
    public string? Value { get; set; }

    [TempData]
    public string? Result { get; set; }
}
