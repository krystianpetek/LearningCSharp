using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers;

[RequireHttps]
[HttpsOnly]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        if(Request.IsHttps)
            return View($"Message","This is the Index action on the Home controller.");
        
        return new StatusCodeResult(StatusCodes.Status403Forbidden);
    }

    public IActionResult Secure()
    {
        if (Request.IsHttps)
            return View($"Message", "This is the secure action on the Home controller.");

        return new StatusCodeResult(StatusCodes.Status403Forbidden);
    }

    [ChangeArgumentsAsyncAttribute]
    public IActionResult Message(string message1, string message2 = "None")
    {
        return View($"Message", $"{message1}, {message2}");
    }
}
