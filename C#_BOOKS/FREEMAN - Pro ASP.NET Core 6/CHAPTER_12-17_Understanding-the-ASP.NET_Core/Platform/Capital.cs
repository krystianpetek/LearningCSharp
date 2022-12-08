namespace Platform;

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
                httpContext.Response.Redirect($"/population/{country}");
                return;
        }

        if (!string.IsNullOrEmpty(capital))
            await httpContext.Response.WriteAsync($"{capital} is the capital of {country}\n");
        else
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
    }
}
