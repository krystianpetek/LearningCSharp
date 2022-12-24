using Platform.Services.Interfaces;

namespace Platform.Services.Formatter;

public static class TypeBroker
{
    private static readonly IResponseFormatter formatter = new HtmlResponseFormatter();
    public static IResponseFormatter Formatter => formatter;
}
