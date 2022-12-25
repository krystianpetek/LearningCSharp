using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.Extensions.FileProviders;
using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

builder.Services.RegisterUrlRouting_Chapter13();

builder.RegisterDependencyInjection_Chapter14();

builder.RegisterConfigurationEnvironment_Chapter15();

var app = builder.Build();

app.Map("/favicon.ico", delegate { }); // ignore favicon

try
{
    // chapter 15 - configuration, environment, logging
    app.EnvironmentLoggingConfiguration_Chapter15();
    app.Run();

    // chapter 14 - dependency injection
    app.DependencyInjectionMiddleware_Chapter14();
    app.Run();

    // chapter 13 - url routing
    app.UrlRoutingMiddleware_Chapter13();
    app.Run(); // prevents calling next middlewares, runs application and block the calling thread until

    // chapter 12 - middleware
    app.CustomMiddleware_Chapter12();
    app.MessageOptionsMiddleware_Chapter12();
    app.Run();

    app.MapGet("/", () => "Hello World!");
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}