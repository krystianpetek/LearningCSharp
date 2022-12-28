using Microsoft.Extensions.Caching.Distributed;
using Platform.Models;
using Platform.Services.Formatter;

namespace Platform;

public class SumEndpoint
{
    public async Task EndpointAsync(HttpContext httpContext, IDistributedCache distributedCache)
    {
        int.TryParse((string?)httpContext.Request.RouteValues["count"], out int count);

        string cacheKey = $"sum_{count}";
        string totalString = await distributedCache.GetStringAsync(cacheKey);

        if (totalString == null)
        {
            long total = 0;
            for (int i = 1; i <= count; i++)
                total += i;

            totalString = $"({DateTime.Now.ToLongTimeString()}) {total}";
            await distributedCache.SetStringAsync(cacheKey, totalString, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            });
        }

        await httpContext.Response.WriteAsync($"({DateTime.Now.ToLongTimeString()}) Total for {count} values:\n{totalString}\n");
    }

    public async Task CachedResponseAsync(HttpContext httpContext,
        IDistributedCache distributedCache,
        IResponseFormatter responseFormatter,
        LinkGenerator linkGenerator)
    {
        int.TryParse((string?)httpContext.Request.RouteValues["count"], out int count);

        long total = 0;
        for (int i = 1; i <= count; i++)
            total += i;

        string totalString = $"({DateTime.Now.ToLongTimeString()}) {total}";

        httpContext.Response.Headers["Cache-Control"] = "public, max-age=120";

        string? url = linkGenerator.GetPathByRouteValues(httpContext, null, new(new KeyValuePair<string, int>("count", count)));

        await responseFormatter.FormatAsync(httpContext,
            $"<div>({DateTime.Now.ToLongTimeString()}) Total for {count}" +
            $" values:</div><div>{totalString}</div>" +
            $"<a href={url}>Reload</a>");
    }

    public async Task DatabaseResponseAsync(HttpContext httpContext, CalculationContext calculationContext)
    {
        int.TryParse((string?)httpContext.Request.RouteValues["count"], out int count);

        long total = calculationContext.Calculations?.FirstOrDefault(c => c.Count == count)?.Result ?? 0;

        if (total == 0)
        {
            for (int i = 1; i <= count; i++)
                total += i;

            calculationContext.Calculations?.Add(new Calculation()
            {
                Count = count,
                Result = total
            });
            await calculationContext.SaveChangesAsync();
        }

        string totalString = $"({DateTime.Now.ToLongTimeString()}) {total}";
        await httpContext.Response.WriteAsync($"({DateTime.Now.ToLongTimeString()}) Total for {count} values:\n{totalString}\n");
    }
}
