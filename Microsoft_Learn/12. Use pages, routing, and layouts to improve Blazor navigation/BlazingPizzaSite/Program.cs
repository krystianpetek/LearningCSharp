using BlazingPizzaSite.Data;
using BlazingPizzaSite.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

// Database register
builder.Services.AddDbContext<PizzaStoreContext>(options =>
{
    options.UseSqlite("Data Source=Data\\pizza.db");
});

// Register services
builder.Services.AddSingleton<OrderState>();

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