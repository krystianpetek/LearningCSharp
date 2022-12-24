﻿namespace Platform.Services;

public interface IResponseFormatter
{
    Task FormatAsync(HttpContext httpContext, string content);
}
