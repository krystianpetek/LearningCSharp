using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.Services;
using Platform.UrlRouting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

builder.Services.RegisterUrlRouting_Chapter13();

builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

var app = builder.Build();

// chapter 14
app.UseMiddleware<WeatherMiddleware>();
IResponseFormatter responseFormatter = new TextResponseFormatter();
app.MapGet("middleware/function/", async (HttpContext httpContext) => // first instance of TextResponseFormatter
{
    await responseFormatter.Format(httpContext, "Middleware function: It is snowing in Chicago.");
});

app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

app.MapGet("endpoint/function/", async (HttpContext httpContext) => // second instance of TextResponseFormatter
{
    await TextResponseFormatter.Singleton.Format(httpContext, $"Endpoint function: It is sunny in Los Angeles.");
});

app.MapGet("endpoint/typebroker", async (HttpContext httpContext) => // instance of HtmlResponseFormatter, defined only in one place
{
    await TypeBroker.Formatter.Format(httpContext, $"Endpoint function: It is sunny in Los Angeles. (Type broker)");
});

app.MapGet("endpoint/dependencyinjection", async (HttpContext httpContext, IResponseFormatter responseFormatter) =>
{
    await responseFormatter.Format(httpContext, "Endpoint function: It is sunny in LA. (DI containter)");
});

app.Run();

// chapter 13
app.UrlRoutingMiddleware_Chapter13();
app.Run(); // prevents calling next middlewares, runs application and block the calling thread until

// chapter 12
app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();
app.MapGet("/", () => "Hello World!");
app.Run();
