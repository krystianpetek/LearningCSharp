using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using SportsStore.Pages;

namespace SportsStore.Tests;

public class CartPageTests
{
    
    [Fact]
    public void Can_Load_Cart()
    {
        var p1 = new Product() { ProductId = 1, Name = "P1" };
        var p2 = new Product() { ProductId = 2, Name = "P2" };
        
        var mockRepo = new Mock<IStoreRepository>();
        mockRepo.Setup(m => m.Products)
            .Returns(new Product[] { p1, p2 }.AsQueryable<Product>());

        var cart = new Cart();
        cart.AddItem(p1,2);
        cart.AddItem(p2,1);

        var mockSession = new Mock<ISession>();
        var data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(cart));
        mockSession.Setup(c => c.TryGetValue(It.IsAny<string>(), out data));

        var mockContext = new Mock<HttpContext>();
        mockContext.SetupGet(c => c.Session).Returns(mockSession.Object);

        var cartModel = new CartModel(mockRepo.Object) {
            PageContext = new PageContext(new ActionContext {
                HttpContext = mockContext.Object,
                RouteData = new RouteData(),
                ActionDescriptor = new PageActionDescriptor()
            })
        };
        cartModel.OnGet("myUrl");
        
        Assert.Equal(2, cartModel.Cart?.Lines.Count);
        Assert.Equal("myUrl", cartModel.ReturnUrl);
    }

    [Fact]
    public void Can_Update_Cart()
    {
        var mockRepo = new Mock<IStoreRepository>();
        mockRepo.Setup(x => x.Products)
            .Returns(new Product[] { new Product() { ProductId = 1, Name = "P1" }}.AsQueryable<Product>());

        var cart = new Cart();

        var mockSession = new Mock<ISession>();
        mockSession.Setup(x => x.Set(It.IsAny<string>(), It.IsAny<byte[]>()))
            .Callback<string, byte[]>((key, value) =>
            {
                cart = JsonSerializer.Deserialize<Cart>(Encoding.UTF8.GetString(value));
            });

        var mockContext = new Mock<HttpContext>();
        mockContext.SetupGet(c => c.Session).Returns(mockSession.Object);
        
        var cartModel = new CartModel(mockRepo.Object) {
            PageContext = new PageContext(new ActionContext {
                HttpContext = mockContext.Object,
                RouteData = new RouteData(),
                ActionDescriptor = new PageActionDescriptor()
            })
        };
        cartModel.OnPost(1, "myUrl");
    
        Assert.Single(cart.Lines);
        Assert.Equal("P1", cart.Lines.First().Product?.Name);
        Assert.Equal(1, cart.Lines.First().Quantity);
    }
}