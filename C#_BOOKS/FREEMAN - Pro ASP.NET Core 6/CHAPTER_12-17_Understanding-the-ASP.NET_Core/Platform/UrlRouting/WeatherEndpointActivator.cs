using Platform.Services;

namespace Platform.UrlRouting;

public class WeatherEndpointActivator
{
    private readonly IResponseFormatter _responseFormatter;

    public WeatherEndpointActivator(IResponseFormatter responseFormatter)
    {
        _responseFormatter = responseFormatter;
    }
    
    public async Task Endpoint(HttpContext httpContext)
    {
        await _responseFormatter.Format(httpContext, $"Endpoint class: It is cloudy in Milan. (WeatherEndpointActivator)");

    }
}
