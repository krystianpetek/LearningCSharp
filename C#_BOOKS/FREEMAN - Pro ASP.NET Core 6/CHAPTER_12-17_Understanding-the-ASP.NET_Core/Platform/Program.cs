using Microsoft.Extensions.Options;
using Platform;
using Platform.CustomMiddleware;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

var app = builder.Build();

// chapter 13
app.UseMiddleware<Population>();
app.UseMiddleware<Capital>();

app.UseRouting();
#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("routing", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Request was routed");
    });
    endpoints.MapGet("capital/uk", new Capital().Invoke);
    endpoints.MapGet("population/paris", new Population().Invoke);
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