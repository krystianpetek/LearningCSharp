using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.Extensions.FileProviders;
using Platform;
using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

builder.Services.RegisterUrlRouting_Chapter13();

builder.RegisterDependencyInjection_Chapter14();

builder.RegisterConfigurationEnvironment_Chapter15();

builder.Services.AddCookiePolicy(cookiePolicyOptions =>
{
    cookiePolicyOptions.CheckConsentNeeded = (HttpContext context) => true;
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession((SessionOptions session) =>
{
    session.IdleTimeout = TimeSpan.FromMinutes(30);
    session.Cookie.IsEssential = true;
});
builder.Services.AddHttpsRedirection(httpsRedirectionOptions =>
{
    httpsRedirectionOptions.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    httpsRedirectionOptions.HttpsPort = 7200;
});
builder.Services.AddHsts(hstsOptions =>
{
    hstsOptions.MaxAge = TimeSpan.FromDays(1);
    hstsOptions.IncludeSubDomains = true;
});
builder.Services.AddHostFiltering(hostFilteringOptions =>
{
    hostFilteringOptions.AllowedHosts.Clear();
    //hostFilteringOptions.AllowedHosts.Add("*.example.com");
});

var app = builder.Build();

app.Map("/favicon.ico", delegate { }); // ignore favicon
try
{
    // chapter 16 - cookies, session, sessionCache, https, hsts, handling exceptions and errors

    if (app.Environment.IsProduction())
    {
        app.UseHsts();
    }

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/error.html");
        app.UseStaticFiles();
    }

    app.UseHttpsRedirection();
    app.UseCookiePolicy();

    app.MapGet("/cookie", async (HttpContext httpContext) =>
    {
        int counter1 = int.Parse(httpContext.Request.Cookies["counter1"] ?? "0") + 1;
        httpContext.Response.Cookies.Append("counter1", $"{counter1}");

        int counter2 = int.Parse(httpContext.Request.Cookies["counter2"] ?? "0") + 1;
        httpContext.Response.Cookies.Append("counter2", $"{counter2}", new CookieOptions
        {
            MaxAge = TimeSpan.FromMinutes(30),
            HttpOnly = true,
            Secure = true,
            IsEssential = true
        });
        await httpContext.Response.WriteAsync($"Counter1: {counter1}, Counter2: {counter2}");
    });

    app.MapGet("clear", (HttpContext httpContext) =>
    {
        httpContext.Response.Cookies.Delete("counter1");
        httpContext.Response.Cookies.Delete("counter2");
        httpContext.Response.Redirect("/");
    });

    app.UseMiddleware<ConsentMiddleware>();
    app.UseSession();

    app.MapGet("session", async (HttpContext httpContext) =>
    {
        int counter1 = (httpContext.Session.GetInt32("sessionCounter1") ?? 0) + 1;
        int counter2 = (httpContext.Session.GetInt32("sessionCounter2") ?? 0) + 1;
        httpContext.Session.SetInt32("sessionCounter1", counter1);
        httpContext.Session.SetInt32("sessionCounter2", counter2);

        await httpContext.Session.CommitAsync();
        await httpContext.Response.WriteAsync($"Session counter1: {counter1}, Session counter2: {counter2}");
    });

    app.MapFallback(async httpContext =>
    {
        await httpContext.Response.WriteAsync($"HTTPS Request: {httpContext.Request.IsHttps}\n");
        await httpContext.Response.WriteAsync($"Hello World!");
    });

    app.UseStatusCodePages("text/html", ResponseStrings.DefaultResponse);
    app.Use(async (HttpContext httpContext, RequestDelegate requestDelegate) =>
    {
        if (httpContext.Request.Path == "/error")
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await Task.CompletedTask;
        }
        else
        {
            await requestDelegate(httpContext);
        }
    });
    app.Run(
    //    context =>
    //{
    //    throw new Exception("Something has gone wrong!");
    //}
    );

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