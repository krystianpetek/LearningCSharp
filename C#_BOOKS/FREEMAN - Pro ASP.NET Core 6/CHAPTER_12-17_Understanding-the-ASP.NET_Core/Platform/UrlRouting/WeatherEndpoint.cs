namespace Platform.UrlRouting;

public class WeatherEndpoint
{
    public static async Task Endpoint(HttpContext httpContext)
    {
        await httpContext.Response.WriteAsync($"Endpoint class: It is cloudy in Milan.");
    }
}
