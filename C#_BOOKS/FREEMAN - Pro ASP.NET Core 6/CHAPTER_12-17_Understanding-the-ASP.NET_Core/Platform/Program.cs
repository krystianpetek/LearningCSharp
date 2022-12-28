using Microsoft.EntityFrameworkCore;
using Platform.Extensions;
using Platform.Models;
using Platform.Services.Formatter;
using Platform.UrlRouting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
        builder.Services.RegisterMessageOptionsConfiguration_Chapter12();
        builder.Services.RegisterUrlRouting_Chapter13();
        builder.RegisterDependencyInjection_Chapter14();
        builder.RegisterConfigurationEnvironment_Chapter15();
        builder.Services.RegisterCookiesSessionHttps_Chapter16();
        builder.RegisterCacheMemoryDbAndResponseDbContext_Chapter17();

        var app = builder.Build();

        app.Map("/favicon.ico", delegate { }); // ignore favicon
        app.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));

        try
        {
            // chapter 17 - in memory cache, sql cache, caching response, seed database with parameter, sensitive data logging
            app.CacheMemoryDbAndResponseDbContext();
            app.Run();

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
    }
}