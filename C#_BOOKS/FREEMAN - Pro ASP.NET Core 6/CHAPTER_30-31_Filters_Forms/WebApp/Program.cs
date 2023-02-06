using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DataContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("ProductConnectionPgSql");
            options.UseNpgsql(connectionString);
            options.EnableSensitiveDataLogging(true);
        });
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddScoped<GuidResponseAttribute>();
        builder.Services.Configure<MvcOptions>(mvcOptions =>
        {
            mvcOptions.Filters.Add<HttpsOnlyAttribute>(); 
            //mvcOptions.Filters.Add(new MessageAttribute("This is the globally-scoped filter"));
        });
        var app = builder.Build();

        var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        dbContext.SeedDatabase();

        app.UseStaticFiles();
        app.MapRazorPages();
        app.MapControllers();
        app.MapDefaultControllerRoute();

        app.MapGet("/hello", () => "Hello World!");
        await app.RunAsync();
    }
}