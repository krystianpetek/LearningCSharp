using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers;

[HtmlTargetElement("tablehead")]
public class TableHeadTagHelper : TagHelper
{
    public string BgColor { get; set; } = "light";

    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "thead";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("class", $"bg-{BgColor} text-white text-center");

        string content = (await output.GetChildContentAsync()).GetContent();
        //output.Content.SetHtmlContent($"<tr><th colspan=\"2\">{content}</th></tr>");

        TagBuilder tag = new TagBuilder("th");
        tag.Attributes["colspan"] = "2";
        tag.InnerHtml.Append(content);

        TagBuilder row = new TagBuilder("tr");
        row.InnerHtml.AppendHtml(tag);

        output.Content.SetHtmlContent(row);
    }
}
