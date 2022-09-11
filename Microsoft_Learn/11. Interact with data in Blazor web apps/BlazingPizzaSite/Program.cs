using BlazingPizzaSite.Data;
using BlazingPizzaSite.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

// Register services
builder.Services.AddSingleton<OrderState>();

// Database register
builder.Services.AddDbContext<PizzaStoreContext>(options =>
{
    options.UseSqlite("Data Source=Data\\PizzaStoreDb.db");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

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