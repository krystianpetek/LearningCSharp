﻿namespace Platform.UrlRouting;

public partial class Population
{
    public static async Task Endpoint(HttpContext httpContext, ILogger<Population> logger)
    {
        //logger.LogDebug($"Started processing for {httpContext.Request.Path}");
        StartingResponse(logger, $"{httpContext.Request.Path}");
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
        logger.LogDebug($"Finished processing for {httpContext.Request.Path}");
    }

    [LoggerMessage(0, LogLevel.Debug, "Starting response for {path}")]
    public static partial void StartingResponse(ILogger logger, string path);
}
