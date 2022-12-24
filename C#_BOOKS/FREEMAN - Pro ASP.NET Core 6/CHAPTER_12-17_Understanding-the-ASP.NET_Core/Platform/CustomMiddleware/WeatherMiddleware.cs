using Platform.Services;

namespace Platform.CustomMiddleware;

public class WeatherMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    //private readonly IResponseFormatter _responseFormatter;

    public WeatherMiddleware(RequestDelegate requestDelegate /*, IResponseFormatter responseFormatter*/)
    {
        _requestDelegate = requestDelegate;
        //_responseFormatter = responseFormatter;
    }
    public async Task InvokeAsync(HttpContext httpContext, IResponseFormatter responseFormatter)
    {
        if (httpContext.Request.Path == "/middleware/class")
            await responseFormatter.Format(httpContext, $"Middleware class: It is raining in London. (WeatherMiddleware)");
        else
            await _requestDelegate(httpContext);
    }
}
