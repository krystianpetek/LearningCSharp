using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstProject.Models;

namespace FirstProject.Controllers;

[Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet]
    public ViewResult Index()
    {
        int hour = DateTime.Now.Hour;
        string viewModel = hour < 12 ? "Good Morning" : "Good Afternoon";
        return View("MyView", viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}