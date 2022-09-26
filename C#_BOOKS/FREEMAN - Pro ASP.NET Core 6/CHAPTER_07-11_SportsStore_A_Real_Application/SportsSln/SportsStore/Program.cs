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
app.MapDefaultControllerRoute();
app.Run();
