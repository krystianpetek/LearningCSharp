using Microsoft.Extensions.Options;
using Platform.MessageOptions;

namespace Platform.Extensions;

public static class MessageOptionsExtensions
{
    public static IServiceCollection RegisterMessageOptionsConfiguration_Chapter12(this IServiceCollection services)
    {
        services.Configure< MessageOption>(options =>
        {
            options.CityName = "Albany";
        });
        return services;
    }

    public static IApplicationBuilder MessageOptionsMiddleware_Chapter12(this WebApplication app)
    {
        app.MapGet("/location", async (HttpContext context, IOptions<MessageOption> messageOptions) =>
        {
            MessageOption _messageOptions = messageOptions.Value;
            await context.Response.WriteAsync($"{_messageOptions.CityName}, {_messageOptions.CountryName}");
        });

        app.UseMiddleware(typeof(LocationMiddleware));

        return app;
    }
}
