using System.Text;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


// fetching request and response middleware
app.Use(async (a, b) =>
{
    Stream originalBodyStream = a.Response.Body;

    try
    {
        Console.WriteLine("before");
        a.Request.EnableBuffering();
        string bodyRequest = await new StreamReader(a.Request.Body).ReadToEndAsync();
        a.Request.Body.Seek(0, SeekOrigin.Begin);


        var memoryFetchingStream = new MemoryStream();
        a.Response.Body = memoryFetchingStream;

        await b(a);

        memoryFetchingStream.Seek(0, SeekOrigin.Begin);

        string bodyResponse = await new StreamReader(memoryFetchingStream).ReadToEndAsync();

        memoryFetchingStream.Seek(0, SeekOrigin.Begin);

        await memoryFetchingStream.CopyToAsync(originalBodyStream);

        Console.WriteLine(bodyResponse);
        Console.WriteLine("after");
    }
    finally
    {
        a.Response.Body = originalBodyStream;
    }
});

app.Run();