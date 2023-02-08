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
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        var app = builder.Build();

        app.UseStaticFiles();
        
        app.MapControllers();
        app.MapControllerRoute(
            name: "controllers",
            pattern: "controllers/{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.SeedDatabase();
        app.Run();
    }
}