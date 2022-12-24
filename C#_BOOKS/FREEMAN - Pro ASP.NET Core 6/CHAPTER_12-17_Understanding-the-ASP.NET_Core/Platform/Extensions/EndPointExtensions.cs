using Microsoft.AspNetCore.Http;
using Platform.Services;
using Platform.UrlRouting;

namespace Platform.Extensions;

public static class EndPointExtensions
{
    public static void MapWeather(this IEndpointRouteBuilder app, string path)
    {
        IResponseFormatter responseFormatter = app.ServiceProvider.GetRequiredService<IResponseFormatter>();

        app.MapGet(path, (HttpContext httpContext) => WeatherEndpoint.Endpoint(httpContext, responseFormatter));
    }
}
