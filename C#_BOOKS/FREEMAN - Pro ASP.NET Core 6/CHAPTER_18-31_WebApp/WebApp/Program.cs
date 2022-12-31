using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Middlewares;
using WebApp.Models;
using WebApp.Routes;

namespace WebApp;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<DataContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("ProductConnectionPgSql");
            options.UseNpgsql(connectionString);
            options.EnableSensitiveDataLogging(true);
        });
        builder.Services.AddControllers().AddNewtonsoftJson().AddXmlSerializerFormatters();
        builder.Services.AddCors(cors => cors.AddPolicy(name: "MyAllowSpecificOrigins", policy =>
        {
            policy.AllowAnyOrigin();
        }));

        //builder.Services.Configure<JsonOptions>(options =>
        //{
        //    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        //});

        builder.Services.Configure<MvcNewtonsoftJsonOptions>(options =>
        {
            options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

        builder.Services.Configure<MvcOptions>(options =>
        {
            options.ReturnHttpNotAcceptable = true;
            options.RespectBrowserAcceptHeader = true;
        });

        var app = builder.Build();
        var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        dbContext.SeedDatabase();

        app.UseMiddleware<TestMiddleware>();

        app.MapProducts(ApiRoutes.MinProducts);

        app.MapControllers();

        app.MapGet("/", () => "Hello World!");

        await app.RunAsync();
    }
}