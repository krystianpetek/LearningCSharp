namespace Platform.CustomMiddleware;

public class QueryStringMiddleware
{
    private readonly RequestDelegate? _requestDelegate;

    public QueryStringMiddleware() { }

    public QueryStringMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == HttpMethods.Get &&
            context.Request.Query["custom"] == "true")
        {
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "text/plain";
            }
            await context.Response.WriteAsync("Class-based Middleware in /branch !\n");
        }
        if (_requestDelegate != null)
            await _requestDelegate(context);
    }
}
