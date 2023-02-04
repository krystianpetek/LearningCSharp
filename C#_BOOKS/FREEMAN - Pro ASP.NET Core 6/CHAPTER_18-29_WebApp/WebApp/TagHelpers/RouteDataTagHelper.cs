using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

[HtmlTargetElement("div",Attributes = "[route-data=true]")]
public class RouteDataTagHelper : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } = new ViewContext();

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute("class", "bg-primary m-2 p-2");

        TagBuilder unorderedList = new TagBuilder("ul");
        unorderedList.Attributes["class"] = "list-group";
        RouteValueDictionary routeValueDictionary = ViewContext.RouteData.Values;
        if(routeValueDictionary.Count > 0)
        {
            foreach(var route in routeValueDictionary)
            {
                TagBuilder item = new TagBuilder("li");
                item.Attributes["class"] = "list-group-item";
                item.InnerHtml.Append($"{route.Key}: {route.Value}");
                unorderedList.InnerHtml.AppendHtml(item);
            }
            output.Content.AppendHtml(unorderedList);
        }
        else
        {
            output.Content.Append("No route data");
        }
    }
}
