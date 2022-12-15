using Platform;
using Platform.CustomMiddleware;
using Platform.MessageOptions;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

// registering middleware class always must be SINGLETON
builder.Services.AddSingleton<PopulationMiddleware>();

builder.Services.Configure<RouteOptions>(routeOptions =>
{
    routeOptions.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
});

var app = builder.Build();

// chapter 13

app.Use( async (HttpContext httpContext, RequestDelegate requestDelegate) =>
{
    Endpoint? endpoint = httpContext.GetEndpoint();
    if (endpoint != null)
        await httpContext.Response.WriteAsync($"{endpoint.DisplayName} selected\n");
    else
        await httpContext.Response.WriteAsync($"No endpoint selected\n");
    
    await requestDelegate(httpContext);
});

app.UseMiddleware<PopulationMiddleware>(); // UseMiddleware immediately invoke this middleware

app.MapGet("routing", async (HttpContext context) =>
{
    await context.Response.WriteAsync("Request was routed");
});

app.MapGet("capital/{country:countryName}",Capital.Endpoint)
    .Add(route => ((RouteEndpointBuilder)route).Order = 1); // order to ambigious route

app.MapGet("capital/{country:regex(^uk|france|monaco|poland$)}", Capital.Endpoint)
    .Add( route => ((RouteEndpointBuilder)route).Order = 2); // ambigious route
app.MapGet("capital/{country=France}", Capital.Endpoint);
app.MapGet("population/{city?}", Population.Endpoint)
    .WithMetadata(new RouteNameMetadata("population"));

app.MapGet("population/paris", async (HttpContext context) =>
{
    var population = app.Services.GetRequiredService<PopulationMiddleware>();
    await population.Invoke(context);
});

app.Map("{number:int}", async context => {
    await context.Response.WriteAsync("Routed to the int endpoint");
})
    .WithDisplayName($"Int endpoint")
    .Add(route => ((RouteEndpointBuilder)route).Order = 1);

app.Map("{number:double}", async context => {
    await context.Response
    .WriteAsync("Routed to the double endpoint");
})
    .WithDisplayName($"Double endpoint")
    .Add(route => ((RouteEndpointBuilder)route).Order = 2);

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

app.MapGet("404", () => "Not found");

app.MapFallback(async (HttpContext httpContext) => await httpContext.Response.WriteAsync("Terminal middleware reached\nRouted to fallback endpoint"));

app.Run(); // prevents calling next middlewares, runs application and block the calling thread until

// chapter 12
app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();
app.MapGet("/", () => "Hello World!");
app.Run();
