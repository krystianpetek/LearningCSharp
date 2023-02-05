using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class SimpleCacheAsyncAttribute : Attribute, IAsyncResourceFilter
{
    private readonly Dictionary<string, IActionResult> CachedResponses = new Dictionary<string, IActionResult>();
    
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        PathString pathString = context.HttpContext.Request.Path;
        if (CachedResponses.ContainsKey(pathString))
        {
            context.Result = CachedResponses[pathString];
            CachedResponses.Remove(pathString);
        }
        else
        {
            ResourceExecutedContext execContext = await next();
            if(execContext.Result != null)
            {
                CachedResponses.Add(pathString, execContext.Result);
            }
        }
    }
}
