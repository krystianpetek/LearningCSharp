namespace Platform.CustomMiddleware;

public class WeatherMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public WeatherMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext.Request.Path == "/middleware/class")
            await httpContext.Response.WriteAsync($"Middleware class: It is raining in London.");
        else
            await _requestDelegate(httpContext);
    }
}
