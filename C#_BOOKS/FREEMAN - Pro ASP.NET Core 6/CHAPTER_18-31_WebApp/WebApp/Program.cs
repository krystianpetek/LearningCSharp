using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp;

public static class Program {

    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<DataContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("ProductConnectionPgSql");
            options.UseNpgsql(connectionString);
            options.EnableSensitiveDataLogging(true);
        });

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        context.SeedDatabase();
        
        await app.RunAsync();        
    }
}