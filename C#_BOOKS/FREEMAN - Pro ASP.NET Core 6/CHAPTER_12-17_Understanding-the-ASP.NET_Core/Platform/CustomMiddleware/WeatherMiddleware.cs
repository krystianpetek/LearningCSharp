using Platform.Services.Formatter;

namespace Platform.CustomMiddleware;

public class WeatherMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public WeatherMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }
    public async Task InvokeAsync(HttpContext httpContext, IResponseFormatter responseFormatter)
    {
        if (httpContext.Request.Path == "/middleware/class")
            await responseFormatter.FormatAsync(httpContext, $"Middleware class: It is raining in London. (WeatherMiddleware)");
        else
            await _requestDelegate(httpContext);
    }
}
