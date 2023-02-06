using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace WebApp.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class MessageAttribute : Attribute, IAsyncAlwaysRunResultFilter, IOrderedFilter
{
    private int counter = 0;
    private string msg;

    public int Order { get; set; }

    public MessageAttribute(string message) => msg = message;

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        Dictionary<string, string> resultData;
        if (context.Result is ViewResult viewResult && viewResult.ViewData.Model is Dictionary<string, string> data)
        {
            resultData = data;
        }
        else
        {
            resultData = new Dictionary<string, string>();
            context.Result = new ViewResult
            {
                ViewName = "/Views/Shared/Message.cshtml",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                {
                    Model = resultData
                }
            };
        }
        while (resultData.ContainsKey($"Message_{counter}"))
        {
            counter++;
        }
        resultData[$"Message_{counter}"] = msg;
        await next();
    }
}
