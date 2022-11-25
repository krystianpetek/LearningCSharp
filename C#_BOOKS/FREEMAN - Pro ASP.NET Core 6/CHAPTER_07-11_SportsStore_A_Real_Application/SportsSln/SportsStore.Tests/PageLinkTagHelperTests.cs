﻿namespace SportsStore.Tests;

public class PageLinkTagHelperTests
{
    [Fact]
    public void Can_Generate_Page_Links()
    {
        var urlHelper = new Mock<IUrlHelper>();
        urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
            .Returns("Test/Page1")
            .Returns("Test/Page2")
            .Returns("Test/Page3");

        var urlHelperFactory = new Mock<IUrlHelperFactory>();
        urlHelperFactory.Setup(f => f.GetUrlHelper(It.IsAny<ActionContext>()))
            .Returns(urlHelper.Object);

        var viewContext = new Mock<ViewContext>();

        PageLinkTagHelper helper = new(urlHelperFactory.Object)
        {
            PageModel = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            },
            PageAction = "Test",
            ViewContext = viewContext.Object
        };

        var ctx = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "");
        var context = new Mock<TagHelperContent>();
        var output = new TagHelperOutput("div", new TagHelperAttributeList(),
            (cache, encoder) => Task.FromResult(context.Object));

        helper.Process(ctx, output);

        Assert.Equal(@"<a href=""Test/Page1"">1</a>" +
                     @"<a href=""Test/Page2"">2</a>" +
                     @"<a href=""Test/Page3"">3</a>",
            output.Content.GetContent());
    }
}