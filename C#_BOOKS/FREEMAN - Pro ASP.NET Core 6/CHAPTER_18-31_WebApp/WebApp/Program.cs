using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Extensions;
using WebApp.Middlewares;
using WebApp.Models;
using WebApp.Routes;
using WebApp.TagHelpers.Components;

namespace WebApp;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Pre21ChapterBuilder();

        builder.Services.AddDbContext<DataContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("ProductConnectionPgSql");
            options.UseNpgsql(connectionString);
            options.EnableSensitiveDataLogging(true);
        });

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.Configure<RazorPagesOptions>(razorOptions =>
        {
            razorOptions.Conventions.AddPageRoute("/Index", "/extra/page/{id:long?}");
        });
        builder.Chapter22Builder();
        builder.Services.AddSingleton<CitiesData>();
        builder.Services.AddTransient<ITagHelperComponent, TimeTagHelperComponent>();
        builder.Services.AddTransient<ITagHelperComponent, TableFooterTagHelperComponent>();

        var app = builder.Build();

        var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        dbContext.SeedDatabase();

        app.Pre21ChapterApp();
        app.Chapter22App();

        app.UseStaticFiles();
        app.MapRazorPages().Add(endpoints =>
        {
            ((RouteEndpointBuilder)endpoints).Order = 2;
        });

        app.MapControllers();
        app.MapControllerRoute(
            name: "Default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute("forms", "controllers/{controller=Home}/{action=Index}/{id?}");

        app.MapGet("/hello", () => "Hello World!");

        await app.RunAsync();
    }
}