using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebApp.Middlewares;
using WebApp.Routes;

namespace WebApp.Extensions;

public static class WebApplicationExtensions
{
    public static void Pre21ChapterBuilder(this WebApplicationBuilder _)
    {
        // mock builder to archive progress with book
        var builder = WebApplication.CreateBuilder();

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

        builder.Services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "WebApp"
            });
        });
    }

    public static void Pre21ChapterApp(this WebApplication _)
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();

        app.UseMiddleware<TestMiddleware>();
        //app.MapProducts(ApiRoutes.MinProducts);

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");
        });

    }
}
