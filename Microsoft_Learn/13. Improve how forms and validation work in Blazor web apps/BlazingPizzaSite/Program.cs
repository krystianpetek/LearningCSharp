using BlazingPizzaSite.Data;
using BlazingPizzaSite.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.WindowsServices;
using Topshelf;

namespace BlazingPizzaSite;

public class Program
{
    public static void Main(string[] args)
    {
        var rc = HostFactory.Run(x =>
        {
            string path = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(path);
            x.Service<StartApp>(s =>
            {
                s.ConstructUsing(host => new StartApp());
                s.WhenStarted(tc => tc.Start());
                s.WhenStopped(tc => tc.Stop());
            });
            x.RunAsLocalSystem();

            x.SetDescription("Blazing Pizza Site");
            x.SetDisplayName("BPS");
            x.SetServiceName("BPS.Service");
        });

        var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
        Environment.ExitCode = exitCode;
    }
}

public class StartApp
{
    public void Stop()
    {
        Environment.Exit(0);
    }

    public void Start()
    {

        var options = new WebApplicationOptions()
        {
            ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
        };

        var builder = WebApplication.CreateBuilder(options);
        builder.WebHost.UseIIS();
        builder.WebHost.UseIISIntegration();

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddHttpClient();

        // Database register
        builder.Services.AddDbContext<PizzaStoreContext>(options => options.UseSqlite("Data Source=Data\\pizza.db"));

        // Register services
        builder.Services.AddSingleton<OrderState>();
        builder.Host.UseWindowsService();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapRazorPages();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");

        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        using var scope = scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
        if (db.Database.EnsureCreated())
        {
            SeedData.Initialize(db);
        }

        app.Run();
    }
}