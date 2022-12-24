using Microsoft.Extensions.Options;
using Platform.MessageOptions;

namespace Platform.CustomMiddleware;

public class LocationMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly MessageOption _messageOptions;
    public LocationMiddleware(RequestDelegate requestDelegate, IOptions<MessageOption> messageOptions)
    {
        _requestDelegate = requestDelegate;
        _messageOptions = messageOptions.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/location")
            await context.Response.WriteAsync($"LocationClass: {_messageOptions.CityName}, {_messageOptions.CountryName}");
        else
            await _requestDelegate(context);
    }
}
