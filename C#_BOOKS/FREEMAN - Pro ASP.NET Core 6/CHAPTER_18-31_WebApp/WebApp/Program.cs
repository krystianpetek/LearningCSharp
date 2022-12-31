using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Extensions;
using WebApp.Middlewares;
using WebApp.Models;
using WebApp.Routes;

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

        var app = builder.Build();
        app.Pre21ChapterApp();
        
        var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        dbContext.SeedDatabase();

        app.UseStaticFiles();
        app.MapControllers();

        app.MapGet("/", () => "Hello World!");

        await app.RunAsync();
    }
}