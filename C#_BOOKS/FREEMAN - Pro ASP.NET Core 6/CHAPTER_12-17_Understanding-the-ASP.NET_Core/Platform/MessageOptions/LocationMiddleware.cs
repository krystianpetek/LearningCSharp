using Microsoft.Extensions.Options;

namespace Platform.MessageOptions
{
    public class LocationMiddleware
    {
        private RequestDelegate _requestDelegate;
        private MessageOptions _messageOptions;
        public LocationMiddleware(RequestDelegate requestDelegate, IOptions<MessageOptions> messageOptions)
        {
            _requestDelegate = requestDelegate;
            _messageOptions = messageOptions.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/location")
            {
                await context.Response.WriteAsync($"LocationClass: {_messageOptions.CityName}, {_messageOptions.CountryName}");
            }
            else
            {
                await _requestDelegate(context);
            }
        }
    }
}
