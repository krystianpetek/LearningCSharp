using Microsoft.AspNetCore.Http.Features;

namespace Platform.CustomMiddleware;

public class ConsentMiddleware
{
    private RequestDelegate _nextDelegate;
    public ConsentMiddleware(RequestDelegate nextDelegate)
    {
        _nextDelegate = nextDelegate;
    }
    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Path == "/consent")
        {
            ITrackingConsentFeature? trackingConsentFeature = httpContext.Features.Get<ITrackingConsentFeature>();

            if (trackingConsentFeature != null)
            {
                if (!trackingConsentFeature.HasConsent)
                    trackingConsentFeature.GrantConsent();
                else
                    trackingConsentFeature.WithdrawConsent();

                await httpContext.Response.WriteAsync(trackingConsentFeature.HasConsent ? "Consent granted\n" : "Consent withdraw\n");
            }
            else
                await _nextDelegate(httpContext);
        }
    }
}
