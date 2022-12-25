using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

builder.Services.RegisterUrlRouting_Chapter13();

builder.RegisterDependencyInjection_Chapter14();

var servicesConfig = builder.Configuration; // use configuration settings to set up services
builder.Services.Configure<MessageOption>(servicesConfig.GetSection("Location"));
var app = builder.Build();

// chapter 15 - configuration, environment
app.MapGet("config", async (HttpContext httpContext, IConfiguration configuration) =>
{
    string? defaultDebug = configuration.GetRequiredSection("Logging:LogLevel").GetValue<string>("Default");
    await httpContext.Response.WriteAsync($"The config setting is: {defaultDebug}");
    string? environment = configuration["ASPNETCORE_ENVIRONMENT"];
    await httpContext.Response.WriteAsync($"\nThe env setting is: {environment}");
});

var pipelineConfig = app.Configuration; // use configuration settings to set up pipeline
app.UseMiddleware<LocationMiddleware>();

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
