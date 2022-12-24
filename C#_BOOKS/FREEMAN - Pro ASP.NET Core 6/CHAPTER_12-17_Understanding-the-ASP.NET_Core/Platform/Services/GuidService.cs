namespace Platform.Services;

public class GuidService : IResponseFormatter
{
    private Guid guid = Guid.NewGuid();
    public async Task Format(HttpContext httpContext, string content)
    {
        await httpContext.Response.WriteAsync($"Guid: {guid}\n{content}");
    }
}
