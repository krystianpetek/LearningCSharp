namespace Platform.GuidGiverService;

public class GuidGiver : IGuidGiver
{
    private Guid guid = Guid.NewGuid();
    public async Task TakeGuidAsync(HttpContext httpContext)
    {
        await httpContext.Response.WriteAsync($"Guid: {guid}\n");
    }
}
