namespace Platform.GuidGiverService;

public class GuidGiverMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    public GuidGiverMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext httpContext, IGuidGiver guidGiver1, IGuidGiver guidGiver2, IGuidGiver guidGiver3)
    {
        if (httpContext.Request.Path == "/giveguid")
        {
            await guidGiver1.TakeGuidAsync(httpContext);
            await guidGiver2.TakeGuidAsync(httpContext);
            await guidGiver3.TakeGuidAsync(httpContext);
        }
        else
        {
            await _requestDelegate(httpContext);
        }
    }
}
