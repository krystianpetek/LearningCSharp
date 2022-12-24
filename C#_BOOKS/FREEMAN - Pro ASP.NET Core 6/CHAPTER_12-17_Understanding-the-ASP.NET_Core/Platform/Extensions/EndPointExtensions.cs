using Platform.CustomMiddleware;
using Platform.GuidGiverService;
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
        //services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
        services.AddTransient<IResponseFormatter, GuidService>();
        services.AddScoped<IGuidGiver, GuidGiver>();

        return services;
    }

    public static IApplicationBuilder DependencyInjectionMiddleware_Chapter14(this WebApplication app)
    {
        app.UseMiddleware<WeatherMiddleware>();
        app.UseMiddleware<GuidGiverMiddleware>();

        IResponseFormatter responseFormatter = new TextResponseFormatter();
        app.MapGet("middleware/function", async (HttpContext httpContext) => // first instance of TextResponseFormatter
        {
            await responseFormatter.Format(httpContext, "Middleware function: It is snowing in Chicago.");
        });

        app.MapWeather("endpoint/class");

        app.MapGet("endpoint/function", async (HttpContext httpContext) => // second instance of TextResponseFormatter
        {
            await TextResponseFormatter.Singleton.Format(httpContext, $"Endpoint function: It is sunny in Los Angeles.");
        });

        app.MapGet("endpoint/typebroker", async (HttpContext httpContext) => // instance of HtmlResponseFormatter, defined only in one place
        {
            await TypeBroker.Formatter.Format(httpContext, $"Endpoint function: It is sunny in Los Angeles. (Type broker)");
        });

        app.MapGet("endpoint/dependencyinjection", async (HttpContext httpContext, IResponseFormatter responseFormatter) => // instance of HtmlResponseFormatter from DI container
        {
            await responseFormatter.Format(httpContext, "Endpoint function: It is sunny in LA. (DI containter)");
        });

        app.MapEndpoint<WeatherEndpointActivator>("endpoint/activator");

        return app;
    }
}
