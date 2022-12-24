using Platform.Services.Interfaces;

namespace Platform.Services.Formatter;

public class TimeResponseFormatter : IResponseFormatter
{
    private readonly ITimeStamper _timeStamper;

    public TimeResponseFormatter(ITimeStamper timeStamper)
    {
        _timeStamper = timeStamper;
    }

    public async Task FormatAsync(HttpContext httpContext, string content)
    {
        await httpContext.Response.WriteAsync($"{_timeStamper.TimeStamp}: {content}");
    }
}
