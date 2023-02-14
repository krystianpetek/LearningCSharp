using Advanced.Models;
using Advanced.Services;
using Microsoft.AspNetCore.Identity;
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

        builder.Services.AddDbContext<IdentityContext>(dbContextOptionsBuilder =>
        {
            string connectionString = builder.Configuration.GetConnectionString("IdentityConnection");
            dbContextOptionsBuilder.UseSqlServer(connectionString);
        });
        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
        builder.Services.Configure<IdentityOptions>(identityOptions =>
        {
            identityOptions.Password.RequiredLength = 8;
            identityOptions.Password.RequireNonAlphanumeric = true;
            identityOptions.Password.RequireLowercase = true;
            identityOptions.Password.RequireUppercase = true;
            identityOptions.Password.RequireDigit = true;

            identityOptions.User.RequireUniqueEmail = true;
            identityOptions.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
        });

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddCors(cors => cors.AddPolicy("policy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

        builder.Services.AddSingleton<ToggleService>();

        var app = builder.Build();

        app.UseStaticFiles();
        
        app.UseAuthentication();

        app.UseCors("policy");
        
        app.MapControllers();
        app.MapControllerRoute(
            name: "controllers",
            pattern: "controllers/{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.SeedDatabase();
        app.Run();
    }
}