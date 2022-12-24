using Platform.CustomMiddleware;
using Platform.GuidGiverService;
using Platform.Services.Formatter;
using Platform.Services.Interfaces;
using Platform.Services.TimeStamper;
using Platform.UrlRouting;
using System.Reflection;

namespace Platform.Extensions;

public static class EndpointExtensions
{
    public static void MapWeather(this IEndpointRouteBuilder app, string path)
    {
        app.MapGet(path, (HttpContext httpContext) => WeatherEndpoint.EndpointAsync(httpContext));
    }

    public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string path, string methodName = "EndpointAsync")
    {
        MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
        if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
            throw new Exception("Method cannot be used");

        ParameterInfo[] methodParams = methodInfo.GetParameters();

        app.MapGet(path, context =>
        {
            T endpointInstance =
            ActivatorUtilities.CreateInstance<T>(context.RequestServices);
            return (Task)methodInfo.Invoke(endpointInstance!,
            methodParams.Select(p => p.ParameterType == typeof(HttpContext)
            ? context
            : context.RequestServices.GetService(p.ParameterType)).ToArray())!;
        });
    }

    public static IServiceCollection RegisterDependencyInjection_Chapter14(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        if (builder.Environment.IsDevelopment())
        {
            services.AddScoped<IResponseFormatter, TextResponseFormatter>();
            services.AddScoped<IResponseFormatter, HtmlResponseFormatter>();
            services.AddScoped<IResponseFormatter, GuidServiceFormatter>();

            services.AddScoped<ITimeStamper, DefaultTimeStamper>();
            services.AddScoped<IResponseFormatter, TimeResponseFormatter>();
        }
        else
        {
            services.AddScoped<IResponseFormatter>((IServiceProvider serviceProvider) =>
            {
                string? typeName = builder.Configuration.GetSection("services").GetValue<string>("IResponseFormatter");
                return (IResponseFormatter)ActivatorUtilities.CreateInstance(serviceProvider, typeName != null ? Type.GetType(typeName, true) : typeof(GuidServiceFormatter));
            });
        }

        services.AddScoped<IGuidGiver, GuidGiver>();

        services.AddSingleton(typeof(ICollection<>), typeof(List<>)); // register generic collection
        return services;
    }

    public static IApplicationBuilder DependencyInjectionMiddleware_Chapter14(this WebApplication app)
    {
        app.UseMiddleware<WeatherMiddleware>();
        app.UseMiddleware<GuidGiverMiddleware>();

        IResponseFormatter responseFormatter = new TextResponseFormatter();
        app.MapGet("middleware/function", async (HttpContext httpContext) => // first instance of TextResponseFormatter
        {
            await responseFormatter.FormatAsync(httpContext, "Middleware function: It is snowing in Chicago.");
        });

        app.MapWeather("endpoint/class");

        app.MapGet("endpoint/function", async (HttpContext httpContext) => // second instance of TextResponseFormatter
        {
            await TextResponseFormatter.Singleton.FormatAsync(httpContext, $"Endpoint function: It is sunny in Los Angeles.");
        });

        app.MapGet("endpoint/typebroker", async (HttpContext httpContext) => // instance of HtmlResponseFormatter, defined only in one place
        {
            await TypeBroker.Formatter.FormatAsync(httpContext, $"Endpoint function: It is sunny in Los Angeles. (Type broker)");
        });

        app.MapGet("endpoint/dependencyinjection", async (HttpContext httpContext, IResponseFormatter responseFormatter) => // instance of HtmlResponseFormatter from DI container
        {
            await responseFormatter.FormatAsync(httpContext, "Endpoint function: It is sunny in LA. (DI containter)");
        });

        app.MapEndpoint<WeatherEndpointActivator>("endpoint/activator");

        app.MapGet("endpoint/lambdaExpression", async (HttpContext httpContext) =>
        {
            IResponseFormatter formatter = httpContext.RequestServices.GetRequiredService<IResponseFormatter>();

            await formatter.FormatAsync(httpContext, "Endpoint lambda expression: It is sunny in LA. (Lambda expression)");
        });
        var guidGiver = app.Services.CreateScope().ServiceProvider.GetRequiredService<IGuidGiver>(); // accessing scoped service when you create a new scope
        //var guidGiver2 = app.Services.GetRequiredService<IGuidGiver>(); // accessing scoped service directly from registered services throws error

        app.MapGet("single", async (HttpContext httpContext) =>
        {
            IResponseFormatter formatter = httpContext.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.FormatAsync(httpContext, "Single service");
        });
        app.MapGet("multiple", async (HttpContext httpContext) =>
        {
            IResponseFormatter formatter = httpContext.RequestServices.GetServices<IResponseFormatter>().First(f => f.RichOutput);
            await formatter.FormatAsync(httpContext, "Multiple services");
        });

        app.MapGet("stringCollection", async (HttpContext httpContext) =>
        {
            ICollection<string> strings = httpContext.RequestServices.GetRequiredService<ICollection<string>>();
            strings.Add($"Request: {DateTime.Now.ToLongTimeString()}");

            foreach (string str in strings)
            {
                await httpContext.Response.WriteAsync($"String: {str}\n");
            }
        });
        app.MapGet("intCollection", async (HttpContext httpContext) =>
        {
            ICollection<int> ints = httpContext.RequestServices.GetRequiredService<ICollection<int>>();
            ints.Add(ints.Count + 1);
            foreach(int value in ints)
            {
                await httpContext.Response.WriteAsync($"Int: {value}\n");
            }
        });
        
        return app;
    }
}
