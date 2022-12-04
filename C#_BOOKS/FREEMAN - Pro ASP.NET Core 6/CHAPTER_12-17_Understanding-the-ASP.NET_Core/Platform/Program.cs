using Microsoft.Extensions.Options;
using Platform;
using Platform.CustomMiddleware;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

// registering middleware class always must be SINGLETON
builder.Services.AddSingleton<Population>();
builder.Services.AddSingleton<Capital>();

var app = builder.Build();

// chapter 13
app.UseMiddleware<Population>(); // UseMiddleware immediately invoke this middleware
app.UseMiddleware<Capital>();

app.UseRouting();
#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("routing", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Request was routed");
    });

    endpoints.MapGet("capital/uk", async (HttpContext context) =>
    {
        var capital = app.Services.GetRequiredService<Capital>();
        await capital.Invoke(context);
    });

    endpoints.MapGet("population/paris", async (HttpContext context) =>
    {
        var population = app.Services.GetRequiredService<Population>();
        await population.Invoke(context);
    });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run(async (HttpContext httpContext) =>
{
    await httpContext.Response.WriteAsync("Terminal middleware reached");
});

// chapter 12
app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();
app.MapGet("/", () => "Hello World!");
app.Run();