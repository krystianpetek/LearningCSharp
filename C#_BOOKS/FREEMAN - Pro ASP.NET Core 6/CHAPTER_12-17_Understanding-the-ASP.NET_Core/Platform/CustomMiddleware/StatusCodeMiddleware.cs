namespace Platform.CustomMiddleware
{
    public class StatusCodeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            await context.Response.WriteAsync($"\nStatus code: {context.Response.StatusCode}");
        }
    }
}
