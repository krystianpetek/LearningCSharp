using Microsoft.Extensions.Caching.Distributed;

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
}
