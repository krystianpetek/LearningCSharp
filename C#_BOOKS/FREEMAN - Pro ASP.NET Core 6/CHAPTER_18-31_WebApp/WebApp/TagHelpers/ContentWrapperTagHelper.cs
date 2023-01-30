using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

[HtmlTargetElement("*", Attributes = "[wrap=true]")]
public class ContentWrapperTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        TagBuilder element = new TagBuilder("div");
        element.Attributes.Add("class", "bg-primary text-white p-2 m-2");
        element.InnerHtml.AppendHtml("Wrapper");

        output.PreElement.AppendHtml(element);
        output.PostElement.AppendHtml(element);
    }
}
