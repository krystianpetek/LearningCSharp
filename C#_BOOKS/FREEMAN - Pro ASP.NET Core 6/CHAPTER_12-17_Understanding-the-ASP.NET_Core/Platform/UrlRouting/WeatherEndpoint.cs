using Platform.Services;

namespace Platform.UrlRouting;

public static class WeatherEndpoint
{
    public static async Task Endpoint(HttpContext httpContext, IResponseFormatter responseFormatter)
    {
        await responseFormatter.Format(httpContext, $"Endpoint class: It is cloudy in Milan. (MapWeather)");
    }
}
