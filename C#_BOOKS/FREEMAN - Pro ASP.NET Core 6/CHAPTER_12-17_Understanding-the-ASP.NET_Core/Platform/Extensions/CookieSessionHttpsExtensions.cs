using Platform.CustomMiddleware;
using System;

namespace Platform.Extensions;

public static class CookieSessionHttpsExtensions
{
    public static IServiceCollection RegisterCookiesSessionHttps_Chapter16(this IServiceCollection builder)
    {
        builder.AddCookiePolicy(cookiePolicyOptions =>
        {
            cookiePolicyOptions.CheckConsentNeeded = (HttpContext context) => true;
        });
        builder.AddDistributedMemoryCache();
        builder.AddSession((SessionOptions session) =>
        {
            session.IdleTimeout = TimeSpan.FromMinutes(30);
            session.Cookie.IsEssential = true;
        });
        builder.AddHttpsRedirection(httpsRedirectionOptions =>
        {
            httpsRedirectionOptions.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            httpsRedirectionOptions.HttpsPort = 7200;
        });
        builder.AddHsts(hstsOptions =>
        {
            hstsOptions.MaxAge = TimeSpan.FromDays(1);
            hstsOptions.IncludeSubDomains = true;
        });
        builder.AddHostFiltering(hostFilteringOptions =>
        {
            hostFilteringOptions.AllowedHosts.Clear();
            //hostFilteringOptions.AllowedHosts.Add("*.example.com");
        });

        return builder;
    }

    public static IApplicationBuilder CookieSessionSessionCacheHttpsHstsExceptions_Chapter16(this WebApplication app)
    {
        if (app.Environment.IsProduction())
            app.UseHsts();

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
                await requestDelegate(httpContext);
        });

        //app.Run(context => throw new Exception("Something went wrong!"));
        return app;
    }
}
