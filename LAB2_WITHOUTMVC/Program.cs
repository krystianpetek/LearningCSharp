using System.Data.Common;
using LAB2_WITHOUTMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<SeedData>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(
    route => route.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=List}/{id?}"));
app.Run();
