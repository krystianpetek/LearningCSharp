﻿namespace Platform.Services.Formatter;

public class HtmlResponseFormatter : IResponseFormatter
{
    public async Task FormatAsync(HttpContext httpContext, string content)
    {
        httpContext.Response.ContentType = "text/html";
        await httpContext.Response.WriteAsync($@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <title>Response</title>
</head>
<body>
    <h2>Formatted response</h2>
    <span>{content}</span>
</body>
</html>
");
    }

    public bool RichOutput => true;
}