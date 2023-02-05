using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class ChangePageArguments : Attribute, IPageFilter
{
    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        // Method intentionally left empty.
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (context.HandlerArguments.ContainsKey("message1"))
            context.HandlerArguments["message1"] = "New message from page filter attribute";
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        // Method intentionally left empty.
    }
}
