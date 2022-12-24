namespace Platform.Services.Formatter;

public class GuidServiceFormatter : IResponseFormatter
{
    private Guid guid = Guid.NewGuid();
    public async Task FormatAsync(HttpContext httpContext, string content)
    {
        await httpContext.Response.WriteAsync($"Guid: {guid}\n{content}");
    }
}
