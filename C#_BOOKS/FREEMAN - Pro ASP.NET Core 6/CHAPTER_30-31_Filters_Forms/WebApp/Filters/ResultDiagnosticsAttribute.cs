using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApp.Filters;

public class ResultDiagnosticsAttribute : Attribute, IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.HttpContext.Request.Query.ContainsKey("diag"))
        {
            Dictionary<string, string> diagData = new Dictionary<string, string>();
            diagData.Add("Result type", context.Result.GetType().Name);

            if (context.Result is ViewResult viewResult)
            {
                diagData["View name"] = viewResult.ViewName;
                diagData["Model type"] = viewResult.Model.GetType().Name;
                diagData["Model data"] = $"{viewResult.Model}";
            }

            if (context.Result is PageResult pageResult)
            {
                diagData["Model type"] = pageResult.Model.GetType().Name;
                diagData["Model data"] = $"{pageResult.Model}";
            }

            context.Result = new ViewResult()
            {
                ViewName = "/Views/Shared/Message.cshtml",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                { 
                    Model = diagData 
                }
            };
        }
        await next();
    }
}
