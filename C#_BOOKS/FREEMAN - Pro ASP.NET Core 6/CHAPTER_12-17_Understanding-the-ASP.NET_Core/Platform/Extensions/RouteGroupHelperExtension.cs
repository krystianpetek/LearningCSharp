using Platform.UrlRouting;

namespace Platform.Extensions;

public static class RouteGroupHelperExtension
{
    public static RouteGroupBuilder PopulationAPI(this RouteGroupBuilder route)
    {
        route.MapGet("population/{city?}", Population.Endpoint);
        return route;
    }
}
