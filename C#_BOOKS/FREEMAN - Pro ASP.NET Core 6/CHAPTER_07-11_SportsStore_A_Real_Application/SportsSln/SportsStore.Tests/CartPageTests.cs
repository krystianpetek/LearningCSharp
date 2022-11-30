using SportsStore.Data.Interface;

namespace SportsStore.Tests;

public class CartPageTests
{
    [Fact]
    public void Can_Load_Cart()
    {
        var p1 = new Product { ProductId = 1, Name = "P1" };
        var p2 = new Product { ProductId = 2, Name = "P2" };

        var mockRepo = new Mock<IStoreRepository>();
        mockRepo.Setup(m => m.Products)
            .Returns(new[] { p1, p2 }.AsQueryable());

        var cart = new Cart();
        cart.AddItem(p1, 2);
        cart.AddItem(p2, 1);

        var cartModel = new CartModel(mockRepo.Object, cart);
        cartModel.OnGet("myUrl");

        Assert.Equal(2, cartModel.Cart?.Lines.Count);
        Assert.Equal("myUrl", cartModel.ReturnUrl);
    }

    [Fact]
    public void Can_Update_Cart()
    {
        var mockRepo = new Mock<IStoreRepository>();
        mockRepo.Setup(x => x.Products)
            .Returns(new Product[] { new Product() { ProductId = 1, Name = "P1" } }.AsQueryable<Product>());
        var cart = new Cart();

        var cartModel = new CartModel(mockRepo.Object, cart);
        cartModel.OnPost(1, "myUrl");

        Assert.Single(cart.Lines);
        Assert.Equal("P1", cart.Lines.First().Product?.Name);
        Assert.Equal(1, cart.Lines.First().Quantity);
    }
}