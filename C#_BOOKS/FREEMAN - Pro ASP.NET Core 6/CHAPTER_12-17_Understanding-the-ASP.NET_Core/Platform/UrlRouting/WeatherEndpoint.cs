using Platform.Services;

namespace Platform.UrlRouting;

public static class WeatherEndpoint
{
    public static async Task EndpointAsync(HttpContext httpContext)
    {
        var responseFormatter = httpContext.RequestServices.GetService<IResponseFormatter>();
        await responseFormatter.FormatAsync(httpContext, $"Endpoint class: It is cloudy in Milan. (MapWeather)");
    }
}
