using Platform;
using Platform.CustomMiddleware;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

// registering middleware class always must be SINGLETON
builder.Services.AddSingleton<PopulationMiddleware>();

var app = builder.Build();

// chapter 13
app.UseMiddleware<PopulationMiddleware>(); // UseMiddleware immediately invoke this middleware

app.MapGet("routing", async (HttpContext context) =>
{
    await context.Response.WriteAsync("Request was routed");
});

app.MapGet("capital/{country}", Capital.Endpoint);
app.MapGet("population/{city}", Population.Endpoint);

app.MapGet("population/paris", async (HttpContext context) =>
{
    var population = app.Services.GetRequiredService<PopulationMiddleware>();
    await population.Invoke(context);
});

app.MapGet("{first}/{second}/{third}", async (HttpContext httpContext) => // https://localhost:7200/apples/oranges/cherries
{
    await httpContext.Response.WriteAsync("Request was routed\n");
    foreach (var route in httpContext.Request.RouteValues)
    {
        await httpContext.Response.WriteAsync($"{route.Key}: {route.Value}\n");
    }
});

app.MapGet("404", () => "Not found");

app.UseRouting();
app.UseEndpoints(_ => { }); // Everything after UseEndpoints - will only run if there was no match before.

app.Use(async (HttpContext httpContext, RequestDelegate _) =>
{
    await _(httpContext);
    await httpContext.Response.WriteAsync("Terminal middleware reached");
});
app.Run(); // prevents calling next middlewares, runs application and block the calling thread until

// chapter 12
app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();
app.MapGet("/", () => "Hello World!");
app.Run();


//app.MapGet("files/{filename}.{ext}", async (HttpContext httpContext) =>
//{
//    await httpContext.Response.WriteAsync($"Request was routed\n");
//    foreach (var route in httpContext.Request.RouteValues)
//    {
//        await httpContext.Response.WriteAsync($"{route.Key}: {route.Value}");
//    }
//});
