using Advanced.Extensions;
using Advanced.Models;
using Advanced.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Advanced;

internal static class Program
{
    private static async Task Main(string[] args)
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
        builder.Services.Configure<CookieAuthenticationOptions>(cookieAuthenticationOptions =>
        {
            cookieAuthenticationOptions.LoginPath = "/Authenticate";
            cookieAuthenticationOptions.LoginPath = "/NotAllowed";
        });
        builder.Services.AddAuthentication(authenticationOptions =>
        {
            authenticationOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            authenticationOptions.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
            .AddCookie(cookieOptions =>
        {
            cookieOptions.Events.DisableRedirectForPath(exp => exp.OnRedirectToLogin, "/api", StatusCodes.Status401Unauthorized);
            cookieOptions.Events.DisableRedirectForPath(exp => exp.OnRedirectToAccessDenied, "/api", StatusCodes.Status403Forbidden);
        });

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddCors(cors => cors.AddPolicy("policy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

        builder.Services.AddSingleton<ToggleService>();

        var app = builder.Build();

        app.UseStaticFiles();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("policy");
        
        app.MapControllers();
        app.MapControllerRoute(
            name: "controllers",
            pattern: "controllers/{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        await app.SeedIdentityDatabase();
        await app.SeedDatabase();
        await app.RunAsync();
    }
}