namespace Platform.GuidGiver
{
    public interface IGuidGiver
    {
        Task TakeGuid(HttpContext httpContext);
    }
}