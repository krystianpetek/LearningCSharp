using System.Text;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// custom middleware when call to api via url https://localhost:7200?custom=true
app.Use(async (context, next) =>
{
    if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware !" +
            "\n");
    }
    await next();
});


// fetching request and response middleware
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

        Console.WriteLine(bodyRequest);
        Console.WriteLine($"Before middleware delegate: {bodyRequest}");

        await requestDelegate(httpContext);

        memoryFetchingStream.Seek(0, SeekOrigin.Begin);
        string bodyResponse = await new StreamReader(memoryFetchingStream).ReadToEndAsync();
        memoryFetchingStream.Seek(0, SeekOrigin.Begin);

        await memoryFetchingStream.CopyToAsync(originalBodyStream);

        Console.WriteLine($"After middleware delegate: {bodyResponse}");
    }
    finally
    {
        httpContext.Response.Body = originalBodyStream;
    }
});

app.Run();