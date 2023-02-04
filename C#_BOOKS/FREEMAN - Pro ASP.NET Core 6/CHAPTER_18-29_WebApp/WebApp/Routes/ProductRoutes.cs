using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Models;

namespace WebApp.Routes;

public static class ProductRoutes
{
    public static WebApplication MapProducts(this WebApplication routeGroupBuilder, string baseRoute)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
        };

        routeGroupBuilder.MapGet($"{baseRoute}/{{id}}", async (HttpContext httpContext, DataContext dataContext) =>
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

        routeGroupBuilder.MapGet($"{baseRoute}/", async (HttpContext httpContext, DataContext dataContext) =>
        {
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(dataContext.Products, jsonSerializerOptions));
        });

        routeGroupBuilder.MapPost($"{baseRoute}/", async (HttpContext httpContext, DataContext dataContext) =>
        {
            Product? product = await JsonSerializer.DeserializeAsync<Product>(httpContext.Request.Body);
            if (product != default)
            {
                var id = await dataContext.Products.AddAsync(product);
                await dataContext.SaveChangesAsync();
                httpContext.Response.StatusCode = StatusCodes.Status201Created;
                httpContext.Response.Headers.Location = $"{product.ProductId}";
            }
        });

        return routeGroupBuilder;
    }
}
