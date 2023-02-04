using WebApp.Models;

namespace WebApp.Middlewares;

public class TestMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public TestMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext httpContext, DataContext dataContext)
    {
        if (httpContext.Request.Path == "/test")
        {
            await httpContext.Response.WriteAsync($"There are {dataContext.Products.Count()} products\n");
            await httpContext.Response.WriteAsync($"There are {dataContext.Categories.Count()} categories\n");
            await httpContext.Response.WriteAsync($"There are {dataContext.Suppliers.Count()} suppliers\n");
        }
        else
        {
            await _requestDelegate(httpContext);
        }
    }
}
