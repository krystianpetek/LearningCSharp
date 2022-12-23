﻿namespace Platform.Services;

public class TextResponseFormatter : IResponseFormatter
{
    private int responseCounter = 0;
    private static TextResponseFormatter? shared;

    public async Task Format(HttpContext httpContext, string content)
    {
        await httpContext.Response.WriteAsync($"Response {++responseCounter}:\n{content}");
    }

    public static TextResponseFormatter Singleton
    {
        get
        {
            shared ??= new TextResponseFormatter();
            return shared;
        }
    }
}