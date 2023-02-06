using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Filters;

namespace WebApp.Controllers;

[RequireHttps]
[HttpsOnly]
[ResultDiagnostics]
//[GuidResponse]
//[GuidResponse]
[Message("this is the controller-scoped filter", Order = 10)]
public class HomeController : Controller
{
    [Message("this is the first action-scoped filter", Order = 1)]
    [Message("this is the second action-scoped filter", Order = -1)]
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

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.ContainsKey("message1"))
            context.ActionArguments["message1"] = "New message from HomeController filter";
    }

    [RangeException]
    public ViewResult GenerateException(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        if(id > 10)
            throw new ArgumentOutOfRangeException(nameof(id));

        return View("Message", $"The value is {id}");
    }
}
