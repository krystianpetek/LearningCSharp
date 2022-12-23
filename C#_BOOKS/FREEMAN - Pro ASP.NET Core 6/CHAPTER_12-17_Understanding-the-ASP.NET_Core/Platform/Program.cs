using Platform.CustomMiddleware;
using Platform.Extensions;
using Platform.Services;
using Platform.UrlRouting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

builder.Services.RegisterUrlRouting_Chapter13();

//builder.Services.

var app = builder.Build();

// chapter 14
app.UseMiddleware<WeatherMiddleware>();
IResponseFormatter responseFormatter = new TextResponseFormatter();
app.MapGet("middleware/function/singleton", async (HttpContext httpContext) => // first instance of TextResponseFormatter
{
    await responseFormatter.Format(httpContext, "Middleware function: It is snowing in Chicago.");
});

app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

app.MapGet("endpoint/function/singleton", async (HttpContext httpContext) => // second instance of TextResponseFormatter
{
    await TextResponseFormatter.Singleton.Format(httpContext,$"Endpoint function: It is sunny in Los Angeles."); 
});

app.MapGet("endpoint/function/typebroker", async (HttpContext httpContext) => // second instance of TextResponseFormatter
{
    await TypeBroker.Formatter.Format(httpContext,$"Endpoint function: It is sunny in Los Angeles."); 
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
