using Platform.Services;
using Platform.UrlRouting;
using System.Reflection;

namespace Platform.Extensions;

public static class EndPointExtensions
{
    public static void MapWeather(this IEndpointRouteBuilder app, string path)
    {
        IResponseFormatter responseFormatter = app.ServiceProvider.GetRequiredService<IResponseFormatter>();

        app.MapGet(path, (HttpContext httpContext) => WeatherEndpoint.Endpoint(httpContext, responseFormatter));
    }

    public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string path, string methodName = "Endpoint")
    {
        MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
        if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
            throw new Exception("Method cannot be used");

        T endpointInstance = ActivatorUtilities.GetServiceOrCreateInstance<T>(app.ServiceProvider);

        app.MapGet(path, methodInfo.CreateDelegate(typeof(RequestDelegate), endpointInstance));
    }


    public static IServiceCollection RegisterDependencyInjection_Chapter14(this IServiceCollection services)
    {

        return services;
    }
    public static IApplicationBuilder DependencyInjectionMiddleware_Chapter14(this WebApplication app)
    {

        return app;
    }
}
