using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;
using Platform.CustomMiddleware;
using Platform.MessageOptions;

namespace Platform.Extensions;

public static class EnvironmentConfigurationExtensions
{
    public static IServiceCollection RegisterConfigurationEnvironment_Chapter15(this WebApplicationBuilder builder)
    {
        var servicesConfig = builder.Configuration; // use configuration settings to set up services
        var serviceEnv = builder.Environment; // use environment to set up services

        builder.Services.Configure<MessageOption>(servicesConfig.GetSection("Location"));

        builder.Services.AddHttpLogging(options =>
        {
            options.LoggingFields = HttpLoggingFields.RequestMethod | HttpLoggingFields.RequestPath | HttpLoggingFields.ResponseStatusCode;
        });

        return builder.Services;
    }

    public static IApplicationBuilder EnvironmentLoggingConfiguration_Chapter15(this WebApplication app)
    {
        app.UseHttpLogging();

        ILogger logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline");
        logger.LogDebug("Pipeline configuration starting");

        var pipelineConfig = app.Configuration; // use configuration settings to set up pipeline
        var pipelineEnv = app.Environment; // use environment to set up pipeline

        app.MapGet("config", async (HttpContext httpContext, IConfiguration configuration, IWebHostEnvironment env) => // https://localhost:7200/config
        {
            string? defaultDebug = configuration.GetRequiredSection("Logging:LogLevel").GetValue<string>("Default");
            await httpContext.Response.WriteAsync($"The config setting is: {defaultDebug}");

            string? environment = configuration["ASPNETCORE_ENVIRONMENT"];
            string? envFromDI = env.EnvironmentName;
            await httpContext.Response.WriteAsync($"\nThe env setting is: {envFromDI}");

            string? wsId = configuration["WebService:Id"];
            await httpContext.Response.WriteAsync($"\nThe secret ID is: {wsId}");
        });

        app.UseMiddleware<LocationMiddleware>();
        app.MapGroup("chapter15").PopulationAPI(); // https://localhost:7200/chapter15/population

        logger.LogDebug("Pipeline configuration complete");

        app.UseStaticFiles(); // wwwroot
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider($"{pipelineEnv.ContentRootPath}/staticfiles"),
            RequestPath = "/files"
        });

        return app;
    }
}
