using WebApp.Models;

namespace WebApp.Middlewares;

public class TestMiddleware
{
    RequestDelegate _nextDelegate;
    public TestMiddleware(RequestDelegate nextDelegate)
    {
        _nextDelegate = nextDelegate;
    }

    public async Task InvokeAsync(HttpContext context, DataContext dataContext)
    {
        if (context.Request.Path == "/test")
        {
            await context.Response.WriteAsync($"There are {dataContext.Products.Count()} products\n");
            await context.Response.WriteAsync($"There are {dataContext.Categories.Count()} categories\n");
            await context.Response.WriteAsync($"There are {dataContext.Suppliers.Count()} suppliers\n");
        }
        else
        {
            await _nextDelegate(context);
        }
    }
}
