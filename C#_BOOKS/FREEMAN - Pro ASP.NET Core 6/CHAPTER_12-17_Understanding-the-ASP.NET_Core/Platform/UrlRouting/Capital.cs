namespace Platform.UrlRouting;

public class Capital
{
    public static async Task Endpoint(HttpContext httpContext)
    {
        string? capital = null;
        string? country = httpContext.Request.RouteValues["country"] as string;
        switch ((country ?? "").ToLower())
        {
            case "uk":
                capital = "London";
                break;
            case "france":
                capital = "Paris";
                break;
            case "monaco":
                LinkGenerator? generator = httpContext.RequestServices.GetService<LinkGenerator>();
                string? url = generator?.GetPathByRouteValues(httpContext, "population", new { city = country });
                if (url != null)
                {
                    httpContext.Response.Redirect(url);
                }
                return;
        }

        if (!string.IsNullOrEmpty(capital))
            await httpContext.Response.WriteAsync($"{capital} is the capital of {country}\n");
        else
            httpContext.Response.Redirect("/404");
    }
}
