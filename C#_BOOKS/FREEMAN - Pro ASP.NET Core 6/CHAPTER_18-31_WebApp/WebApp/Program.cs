using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Middlewares;
using WebApp.Models;
using WebApp.Routes;

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
        builder.Services.AddControllers();
        builder.Services.AddCors(cors => cors.AddPolicy(name: "MyAllowSpecificOrigins", policy =>
        {
            policy.AllowAnyOrigin();
        }));

        var app = builder.Build();
        var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        dbContext.SeedDatabase();

        app.UseMiddleware<TestMiddleware>();

        app.MapProducts(ApiRoutes.MinProducts);

        app.MapControllers();

        app.MapGet("/", () => "Hello World!");

        await app.RunAsync();
    }
}