using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class ChangeArgumentsAsyncAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.ContainsKey("message1"))
            context.ActionArguments["message1"] = "New message from action filter";

        var actionExecutedContext = await next();
    }
}
// executed home/message?message1=hello&message2=world