using Microsoft.Extensions.Options;

namespace Platform.MessageOptions
{
    public static class MessageOptionsExtensions
    {
        public static IServiceCollection RegisterMessageOptionsConfiguration_Chapter12(this IServiceCollection services)
        {
            services.Configure<MessageOptions>(options =>
            {
                options.CityName = "Albany";
            });
            return services;
        }

        public static IApplicationBuilder MessageOptionsMiddleware_Chapter12(this WebApplication app)
        {
            app.MapGet("/location", async (HttpContext context, IOptions<MessageOptions> messageOptions) =>
            {
                MessageOptions _messageOptions = messageOptions.Value;
                await context.Response.WriteAsync($"{_messageOptions.CityName}, {_messageOptions.CountryName}");
            });
            
            app.UseMiddleware(typeof(LocationMiddleware));

            return app;
        }
    }
}
