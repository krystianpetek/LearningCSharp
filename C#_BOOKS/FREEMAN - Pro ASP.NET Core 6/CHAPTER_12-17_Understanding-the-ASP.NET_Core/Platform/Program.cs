using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.Extensions.FileProviders;
using Platform;
using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.MessageOptions;

var services = WebApplication.CreateBuilder(args);

services.Services.RegisterCustomMiddlewareDependencies_Chapter12();
services.Services.RegisterMessageOptionsConfiguration_Chapter12();
services.Services.RegisterUrlRouting_Chapter13();
services.RegisterDependencyInjection_Chapter14();
services.RegisterConfigurationEnvironment_Chapter15();
services.Services.RegisterCookiesSessionHttps_Chapter16();


var app = services.Build();

app.Map("/favicon.ico", delegate { }); // ignore favicon
try
{
    // chapter 16 - cookies, session, sessionCache, https, hsts, handling exceptions and errors
    app.CookieSessionSessionCacheHttpsHstsExceptions_Chapter16();
    app.Run();

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
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}