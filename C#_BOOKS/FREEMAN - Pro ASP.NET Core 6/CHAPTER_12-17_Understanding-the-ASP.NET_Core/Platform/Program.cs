using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.GuidGiverService;
using Platform.Services;
using Platform.UrlRouting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

builder.Services.RegisterUrlRouting_Chapter13();

builder.Services.RegisterDependencyInjection_Chapter14();

var app = builder.Build();

// chapter 14
app.DependencyInjectionMiddleware_Chapter14();
app.Run();

// chapter 13
app.UrlRoutingMiddleware_Chapter13();
app.Run(); // prevents calling next middlewares, runs application and block the calling thread until

// chapter 12
app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();
app.Run();

app.MapGet("/", () => "Hello World!");
app.Run();
