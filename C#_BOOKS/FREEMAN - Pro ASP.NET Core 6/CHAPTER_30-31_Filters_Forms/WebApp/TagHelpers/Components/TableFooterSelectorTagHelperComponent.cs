using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers.Components;

[HtmlTargetElement("table")]
public class TableFooterSelectorTagHelperComponent : TagHelperComponentTagHelper
{
    public TableFooterSelectorTagHelperComponent(ITagHelperComponentManager tagHelperComponentManager, ILoggerFactory loggerFactory) : base(tagHelperComponentManager, loggerFactory)
    { }
}

public class TableFooterTagHelperComponent : TagHelperComponent
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if(output.TagName == "table")
        {
            TagBuilder cell = new TagBuilder("td");
            cell.Attributes.Add("colspan", "2");
            cell.Attributes.Add("class", "bg-dark text-white text-center");
            cell.InnerHtml.Append("Table Footer");

            TagBuilder row = new TagBuilder("tr");
            row.InnerHtml.AppendHtml(cell);

            TagBuilder footer = new TagBuilder("tfoot");
            footer.InnerHtml.AppendHtml(row);
            output.PostContent.AppendHtml(footer);
        }
    }
}