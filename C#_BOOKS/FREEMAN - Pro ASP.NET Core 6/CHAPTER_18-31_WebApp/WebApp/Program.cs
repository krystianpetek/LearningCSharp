using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Middlewares;
using WebApp.Models;

namespace WebApp;

public static class Program
{
    private const string PRODUCTS = "api/products";

    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<DataContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("ProductConnectionPgSql");
            options.UseNpgsql(connectionString);
            options.EnableSensitiveDataLogging(true);
        });

        var app = builder.Build();
        var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        dbContext.SeedDatabase();

        app.UseMiddleware<TestMiddleware>();

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
        };

        var products = app.MapGroup($"/{PRODUCTS}");
        products.MapGet($"/{{id}}", async (HttpContext httpContext, DataContext dataContext) =>
        {
            if (long.TryParse(httpContext.Request.RouteValues["id"] as string, out long id))
            {
                Product? product = await dataContext.Products.FirstOrDefaultAsync(c => c.ProductId == id);
                if (product == default)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    return;
                }

                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize<Product>(product, jsonSerializerOptions));
                return;
            }
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        });

        products.MapGet("/", async (HttpContext httpContext, DataContext dataContext) =>
        {
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(dataContext.Products,jsonSerializerOptions));
        });

        products.MapPost("/", async (HttpContext httpContext, DataContext dataContext) =>
        {
            Product? product = await JsonSerializer.DeserializeAsync<Product>(httpContext.Request.Body);
            if (products != default)
            {
                var id = await dataContext.Products.AddAsync(product);
                await dataContext.SaveChangesAsync();
                httpContext.Response.StatusCode = StatusCodes.Status201Created;
                httpContext.Response.Headers.Location = $"{product.ProductId}";
            }
        });

        app.MapGet("/", () => "Hello World!");

        await app.RunAsync();
    }
}