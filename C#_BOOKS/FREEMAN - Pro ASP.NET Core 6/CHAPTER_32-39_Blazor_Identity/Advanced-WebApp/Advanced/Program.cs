using Advanced.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<DataContext>(dbContextOptionsBuilder =>
        {
            string connectionString = builder.Configuration.GetConnectionString("PeopleConnection");
            
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
        });
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.SeedDatabase();
        app.Run();
    }
}