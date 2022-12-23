namespace Platform.Services;

public class TextResponseFormatter : IResponseFormatter
{
    private int responseCounter = 0;
    public async Task Format(HttpContext httpContext, string content)
    {
        await httpContext.Response.WriteAsync($"Response {++responseCounter}:\n{content}");
    }
}
