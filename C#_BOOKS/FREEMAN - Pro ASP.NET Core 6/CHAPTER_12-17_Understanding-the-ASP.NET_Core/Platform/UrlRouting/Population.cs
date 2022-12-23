namespace Platform.UrlRouting;

public class Population
{
    public static async Task Endpoint(HttpContext httpContext)
    {
        string? city = httpContext.Request.RouteValues["city"] as string ?? "london";
        int? pop = null;
        switch (city.ToLower())
        {
            case "london":
                pop = 8_136_000;
                break;
            case "paris":
                pop = 2_141_000;
                break;
            case "monaco":
                pop = 39_000;
                break;
        }
        if (pop.HasValue)
            await httpContext.Response.WriteAsync($"City: {city}, Population: {pop}");
        else
            httpContext.Response.Redirect("/404");
        //httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
    }
}
