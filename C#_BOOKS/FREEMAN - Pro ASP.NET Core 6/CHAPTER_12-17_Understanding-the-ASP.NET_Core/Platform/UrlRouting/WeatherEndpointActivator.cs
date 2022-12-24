using Platform.Services;

namespace Platform.UrlRouting;

public class WeatherEndpointActivator
{
    private readonly IResponseFormatter _responseFormatter;

    public WeatherEndpointActivator(IResponseFormatter responseFormatter)
    {
        _responseFormatter = responseFormatter;
    }

    public async Task EndpointAsync(HttpContext httpContext)
    {
        await _responseFormatter.FormatAsync(httpContext, $"Endpoint class: It is cloudy in Milan. (WeatherEndpointActivator)");

    }
}
