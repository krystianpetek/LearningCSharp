using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionStrings:SportsStoreConnection"];
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
var app = builder.Build();

app.EnsureData();
app.UseStaticFiles();

app.MapControllerRoute("catpage", "{category}/Page{productPage:int}", new { Controller = "Home", Action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{Category}", new { Controller = "Home", Action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();
app.Run();
