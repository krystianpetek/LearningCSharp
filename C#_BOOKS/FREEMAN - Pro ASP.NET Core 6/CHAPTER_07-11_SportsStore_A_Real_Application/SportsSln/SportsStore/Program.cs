using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // mvc framework
builder.Services.AddRazorPages(); // Razor pages framework
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionStrings:SportsStoreDocker"];
    options.UseSqlServer(connectionString);

    //options.UseInMemoryDatabase(databaseName: "SportsStore");
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

app.EnsureData();
app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("categorypage", "{category}/Page{productPage:int}", new { Controller = "Home", Action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("pagination", "Products/Page{productPage}",new { Controller = "Home", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();
