using Microsoft.EntityFrameworkCore;
using Platform.Models;
using Platform.Services.Formatter;
using Platform.UrlRouting;

namespace Platform.Extensions;

public static class CacheMemoryDbExtensions
{
    public static WebApplicationBuilder RegisterCacheMemoryDbAndResponseDbContext_Chapter17(this WebApplicationBuilder builder)
    {
        //builder.Services.AddDistributedMemoryCache(options =>
        //{
        //    options.SizeLimit = 200;
        //});

        builder.Services.AddDistributedSqlServerCache(options =>
        {
            options.ConnectionString = builder.Configuration.GetConnectionString("CacheConnection");
            options.TableName = "DataCache";
            options.SchemaName = "dbo";
        });

        builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
        builder.Services.AddResponseCaching();

        builder.Services.AddDbContext<CalculationContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("CalcConnection");
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        builder.Services.AddTransient<SeedData>();

        return builder;
    }

    public static WebApplication CacheMemoryDbAndResponseDbContext(this WebApplication app)
    {
        app.UseResponseCaching();
        app.MapEndpoint<SumEndpoint>("/sum/{count:int=2000000000}");
        app.MapEndpoint<SumEndpoint>("/cachedSum/{count:int=2000000000}", "CachedResponseAsync");
        app.MapEndpoint<SumEndpoint>("/databaseSum/{count:int=2000000000}", "DatabaseResponseAsync");

        bool cmdLineInit = (app.Configuration["INITDB"] ?? "false") == "true";
        if (app.Environment.IsDevelopment() && cmdLineInit)
        {
            var seedData = app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedData>();
            seedData.SeedDatabase();
            Environment.Exit(0);
        }

        return app;
    }
}
