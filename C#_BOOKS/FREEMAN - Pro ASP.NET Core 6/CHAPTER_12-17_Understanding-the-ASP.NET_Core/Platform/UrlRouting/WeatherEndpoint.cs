using Platform.Services.Formatter;

namespace Platform.UrlRouting;

public static class WeatherEndpoint
{
    public static async Task EndpointAsync(HttpContext httpContext)
    {
        IResponseFormatter responseFormatter = httpContext.RequestServices.GetService<IResponseFormatter>()!;
        await responseFormatter.FormatAsync(httpContext, $"Endpoint class: It is cloudy in Milan. (MapWeather)");
    }
}
