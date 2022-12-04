using Microsoft.Extensions.Options;
using Platform;
using Platform.CustomMiddleware;
using Platform.MessageOptions;
using System.Text;

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

app.MapGet("routing", async (HttpContext context) =>
{
    await context.Response.WriteAsync("Request was routed");
});
app.MapGet("capital/uk", async (HttpContext context) =>
{
    var capital = app.Services.GetRequiredService<Capital>();
    await capital.Invoke(context);
});
app.MapGet("population/paris", async (HttpContext context) =>
{
    var population = app.Services.GetRequiredService<Population>();
    await population.Invoke(context);
});

app.MapGet("404", () => "Not found");

app.UseRouting();
app.UseEndpoints(_ => { }); // Everything after UseEndpoints - will only run if there was no match before.

app.Use(async (HttpContext httpContext, RequestDelegate _) =>
{
    await _(httpContext);
    await httpContext.Response.WriteAsync("Terminal middleware reached");
    httpContext.Response.Redirect("/404");
});
app.Run(); // prevents calling next middlewares, runs application and block the calling thread until

// chapter 12
app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();
app.MapGet("/", () => "Hello World!");
app.Run();