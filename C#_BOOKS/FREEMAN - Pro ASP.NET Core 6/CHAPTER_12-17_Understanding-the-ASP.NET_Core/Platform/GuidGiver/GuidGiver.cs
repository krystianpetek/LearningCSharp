namespace Platform.GuidGiver;

public class GuidGiver : IGuidGiver
{
    private Guid guid = Guid.NewGuid();
    public async Task TakeGuid(HttpContext httpContext)
    {
        await httpContext.Response.WriteAsync($"Guid: {guid}\n");
    }
}
