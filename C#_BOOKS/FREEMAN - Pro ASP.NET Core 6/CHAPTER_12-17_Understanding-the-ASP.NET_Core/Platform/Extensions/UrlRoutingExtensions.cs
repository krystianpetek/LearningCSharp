using Platform.UrlRouting;

namespace Platform.Extensions;

public static class UrlRoutingExtensions
{
    public static IServiceCollection RegisterUrlRouting_Chapter13(this IServiceCollection services)
    {
        // registering middleware class always must be SINGLETON
        services.AddSingleton<PopulationMiddleware>();

        services.Configure<RouteOptions>(routeOptions =>
        {
            routeOptions.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
        });
        return services;
    }

    public static IApplicationBuilder UrlRoutingMiddleware_Chapter13(this WebApplication app)
    {
        #region UseMiddleware / Use invoke on every call
        app.UseMiddleware<PopulationMiddleware>(); // UseMiddleware immediately invoke this middleware

        app.Use(async (HttpContext httpContext, RequestDelegate requestDelegate) => // show endpoint name in every endpoint
        {
            Endpoint? endpoint = httpContext.GetEndpoint();
            if (endpoint != null)
                await httpContext.Response.WriteAsync($"{endpoint.DisplayName} selected\n");
            else
                await httpContext.Response.WriteAsync($"No endpoint selected\n");

            await requestDelegate(httpContext);
        });
        #endregion

        app.MapGet("routing", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Request was routed");
        });

        #region Capital/Population endpoints
        app.MapGet("capital/{country:countryName}", Capital.Endpoint)
            .Add(route => ((RouteEndpointBuilder)route).Order = 1); // order to ambigious route

        app.MapGet("capital/{country:regex(^uk|france|monaco|poland$)}", Capital.Endpoint)
            .Add(route => ((RouteEndpointBuilder)route).Order = 2); // ambigious route

        app.MapGet("capital/{country=France}", Capital.Endpoint);

        app.MapGet("population/{city?}", Population.Endpoint)
            .WithMetadata(new RouteNameMetadata("population"));

        app.MapGet("population/paris", async (HttpContext context) =>
        {
            var population = app.Services.GetRequiredService<PopulationMiddleware>();
            await population.Invoke(context);
        });
        #endregion

        #region Number ambigious route in when passed some values for example 1(int) and 1.3(double)
        app.Map("{number:int}", async context =>
        {
            await context.Response.WriteAsync("Routed to the int endpoint");
        })
            .WithDisplayName($"Int endpoint")
            .Add(route => ((RouteEndpointBuilder)route).Order = 1);

        app.Map("{number:double}", async context =>
        {
            await context.Response
            .WriteAsync("Routed to the double endpoint");
        })
            .WithDisplayName($"Double endpoint")
            .Add(route => ((RouteEndpointBuilder)route).Order = 2);
        #endregion

        #region Constraint and condition matching routes
        app.MapGet("{first:alpha:length(3)}/{second:bool}", async (HttpContext httpContext) => // https://localhost:7200/abc/true
        {
            await httpContext.Response.WriteAsync("Constraint segment match, first is alpha and has exactly 3 letters and second segment is bool\n");
            foreach (var route in httpContext.Request.RouteValues)
            {
                await httpContext.Response.WriteAsync($"{route.Key}: {route.Value}\n");
            }
        });

        app.MapGet("{first}/{second}/{*catchall}", async (HttpContext httpContext) => // https://localhost:7200/apples/oranges/cherries
        {
            await httpContext.Response.WriteAsync("Catchall matched. Request was routed\n");
            foreach (var route in httpContext.Request.RouteValues)
            {
                await httpContext.Response.WriteAsync($"{route.Key}: {route.Value}\n");
            }
        });

        app.MapGet("files/{filename}.{ext}", async (HttpContext httpContext) => // https://localhost:7200/files/myfile.txt
        {
            await httpContext.Response.WriteAsync($"Request was routed\n");
            foreach (var route in httpContext.Request.RouteValues)
            {
                await httpContext.Response.WriteAsync($"{route.Key}: {route.Value}\n");
            }
        });
        #endregion

        app.MapGet("404", () => "Not found");

        app.MapFallback(async (HttpContext httpContext) => await httpContext.Response.WriteAsync("Terminal middleware reached\nRouted to fallback endpoint"));

        return app;
    }
}
