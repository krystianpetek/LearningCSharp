using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Data.DbContexts;
using SportsStore.Data.Interface;
using SportsStore.Data.Models;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // mvc framework
builder.Services.AddRazorPages(); // Razor pages framework
builder.Services.AddServerSideBlazor(); // blazor server side framework

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    //options.UseInMemoryDatabase(databaseName: "SportsStore");
    var connectionString = builder.Configuration["ConnectionStrings:SportsStoreDocker"];
    options.UseSqlServer(connectionString);
}); // entity framework sportsstore db

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    //options.UseInMemoryDatabase(databaseName: "Identity");
    var connectionString = builder.Configuration.GetConnectionString("IdentityDocker");
    options.UseSqlServer(connectionString);
}); // entity framework identity db

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>(); // asp.net core identity framework

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("categorypage", "{category}/Page{productPage:int}", new { Controller = "Home", Action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", action = "Index", productPage = 1 });
app.MapDefaultControllerRoute();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

app.EnsureData();
app.Run();
