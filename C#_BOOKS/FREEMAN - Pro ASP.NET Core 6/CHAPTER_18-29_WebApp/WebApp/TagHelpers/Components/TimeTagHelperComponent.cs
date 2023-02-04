using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers.Components;

public class TimeTagHelperComponent : TagHelperComponent
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        string timeStamp = DateTime.Now.ToLongTimeString();

        if(output.TagName == "body")
        {
            TagBuilder element = new TagBuilder("div");
            element.Attributes.Add("class", "bg-info text-white m-2 p-2");
            element.InnerHtml.Append($"Time: {timeStamp}");
            output.PreContent.AppendHtml(element);
        }
    }
}
