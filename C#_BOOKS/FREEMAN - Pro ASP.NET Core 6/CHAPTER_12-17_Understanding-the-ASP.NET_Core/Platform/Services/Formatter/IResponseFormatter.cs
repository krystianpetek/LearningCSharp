namespace Platform.Services.Formatter;

public interface IResponseFormatter
{
    Task FormatAsync(HttpContext httpContext, string content);
    public bool RichOutput => false;
}
