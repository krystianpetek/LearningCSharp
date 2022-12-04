using Microsoft.Extensions.Options;
using Platform.CustomMiddleware;
using Platform.MessageOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterCustomMiddlewareDependencies_Chapter12();
builder.Services.RegisterMessageOptionsConfiguration_Chapter12();

var app = builder.Build();

app.CustomMiddleware_Chapter12();
app.MessageOptionsMiddleware_Chapter12();

app.MapGet("/", () => "Hello World!");

app.Run();