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
app.Run(async (HttpContext httpContext) =>
{
    await httpContext.Response.WriteAsync("Terminal middleware reached");
});

// chapter 12
app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();
app.MapGet("/", () => "Hello World!");
app.Run();