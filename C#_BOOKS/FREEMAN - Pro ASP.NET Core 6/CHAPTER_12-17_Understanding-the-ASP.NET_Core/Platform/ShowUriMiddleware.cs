using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Text;
using System.Web;

namespace Platform
{
    public class ShowUriMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ShowUriMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            UriBuilder baseUrl = new UriBuilder("https", "localhost", 7200);
            UriBuilder baseUrlWithQuery = new UriBuilder("https", "localhost", 7200, context.Request.QueryString.Value);

            //var parsedQuery = HttpUtility.ParseQueryString(context.Request.QueryString.Value);


            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "text/plain";
            }
            
            await context.Response.WriteAsync($"{baseUrl}{context.Request.QueryString.Value}\n");

            await _requestDelegate(context);
        }
    }
}
