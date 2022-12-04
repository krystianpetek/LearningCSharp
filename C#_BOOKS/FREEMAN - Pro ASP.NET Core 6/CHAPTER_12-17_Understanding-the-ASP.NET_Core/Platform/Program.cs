using Platform;
using System.Text;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<StatusCodeMiddleware>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// my custom middleware fetching request and response middleware
app.Use(async (httpContext, requestDelegate) =>
{
    Stream originalBodyStream = httpContext.Response.Body;

    try
    {
        httpContext.Request.EnableBuffering();
        string bodyRequest = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
        httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

        var memoryFetchingStream = new MemoryStream();
        httpContext.Response.Body = memoryFetchingStream;

        Console.WriteLine($"Before middleware delegate: \n{bodyRequest}\n");

        await requestDelegate(httpContext);

        memoryFetchingStream.Seek(0, SeekOrigin.Begin);
        string bodyResponse = await new StreamReader(memoryFetchingStream).ReadToEndAsync();
        memoryFetchingStream.Seek(0, SeekOrigin.Begin);

        await memoryFetchingStream.CopyToAsync(originalBodyStream);

        Console.WriteLine($"After middleware delegate: \n{bodyResponse}\n");
    }
    finally
    {
        httpContext.Response.Body = originalBodyStream;
    }
});

// custom middleware to show uri in browser response
app.UseMiddleware<ShowUriMiddleware>();

// custom class middleware when call to api via url https://localhost:7200?custom=true
app.UseMiddleware<QueryStringMiddleware>();

// custom middleware when call to api via url https://localhost:7200?custom=true
app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware !\n");
    }
    await next();
});

// custom middleware with implementation of interface IMiddleware, invoked in return path 
app.UseMiddleware<StatusCodeMiddleware>();

app.Run();