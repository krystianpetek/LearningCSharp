namespace Platform.GuidGiverService
{
    public interface IGuidGiver
    {
        Task TakeGuidAsync(HttpContext httpContext);
    }
}