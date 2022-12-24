namespace Platform.GuidGiverService
{
    public interface IGuidGiver
    {
        Task TakeGuid(HttpContext httpContext);
    }
}