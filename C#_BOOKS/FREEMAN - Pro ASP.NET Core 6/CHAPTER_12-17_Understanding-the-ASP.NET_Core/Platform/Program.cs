using Microsoft.AspNetCore.Routing.Patterns;
using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

builder.Services.RegisterUrlRouting_Chapter13();

builder.RegisterDependencyInjection_Chapter14();

var servicesConfig = builder.Configuration; // use configuration settings to set up services
var serviceEnv = builder.Environment; // use environment to set up services
builder.Services.Configure<MessageOption>(servicesConfig.GetSection("Location"));
var app = builder.Build();

try
{
    // chapter 15 - configuration, environment, logging

    ILogger logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline");
    logger.LogDebug("Pipeline configuration starting");

    var pipelineConfig = app.Configuration; // use configuration settings to set up pipeline
    var pipelineEnv = app.Environment; // use environment to set up pipeline

    app.MapGet("config", async (HttpContext httpContext, IConfiguration configuration, IWebHostEnvironment env) =>
    {
        string? defaultDebug = configuration.GetRequiredSection("Logging:LogLevel").GetValue<string>("Default");
        await httpContext.Response.WriteAsync($"The config setting is: {defaultDebug}");

        string? environment = configuration["ASPNETCORE_ENVIRONMENT"];
        string? envFromDI = env.EnvironmentName;
        await httpContext.Response.WriteAsync($"\nThe env setting is: {envFromDI}");

        string? wsId = configuration["WebService:Id"];
        await httpContext.Response.WriteAsync($"\nThe secret ID is: {wsId}");
    });

    app.UseMiddleware<LocationMiddleware>();
    app.MapGroup("chapter15").PopulationAPI();

    logger.LogDebug("Pipeline configuration complete");
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
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}