using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Advanced.Extensions;

public static class CookieAuthenticationExtensions
{
    public static void DisableRedirectForPath(this CookieAuthenticationEvents cookieAuthenticationEvents,
        Expression<Func<CookieAuthenticationEvents, Func<RedirectContext<CookieAuthenticationOptions>, Task>>> expression,
        string path,
        int statusCode)
    {
        string propertyName = ((MemberExpression)expression.Body).Member.Name;
        var oldHandler = expression.Compile().Invoke(cookieAuthenticationEvents);

        Func<RedirectContext<CookieAuthenticationOptions>, Task> newHandler = context =>
        {
            if (context.Request.Path.StartsWithSegments(path))
            {
                context.Response.StatusCode = statusCode;
            }
            else
            {
                oldHandler(context);
            }
            return Task.CompletedTask;
        };

        typeof(CookieAuthenticationEvents).GetProperty(propertyName)?.SetValue(cookieAuthenticationEvents, newHandler);
    }

    // i don't know how this extension work but all in front of me
}
