namespace SportsStore.Tests;

public class CartTests
{
    [Fact]
    public void Can_Add_New_Lines()
    {
        // Arrange
        var p1 = new Product { ProductId = 1, Name = "P1" };
        var p2 = new Product { ProductId = 2, Name = "P2" };
        var cart = new Cart();

        // Act
        cart.AddItem(p1, 1);
        cart.AddItem(p2, 1);
        var cartLine = cart.Lines.ToArray();

        // Assert
        Assert.Equal(2, cartLine.Length);
        Assert.Equal(p1, cartLine[0].Product);
        Assert.Equal(p2, cartLine[1].Product);
    }

    [Fact]
    public void Can_Add_Quantity_For_Existing_Lines()
    {
        // Arrange
        var p1 = new Product { ProductId = 1, Name = "P1" };
        var p2 = new Product { ProductId = 2, Name = "P2" };
        var cart = new Cart();

        // Act
        cart.AddItem(p1, 1);
        cart.AddItem(p2, 1);
        cart.AddItem(p1, 10);
        var cartLine = cart.Lines.OrderBy(x => x.Product?.ProductId).ToList();

        // Assert
        Assert.Equal(2, cartLine.Count);
        Assert.Equal(11, cartLine[0].Quantity);
        Assert.Equal(1, cartLine[1].Quantity);
    }

    [Fact]
    public void Can_Remove_Line()
    {
        // Arrange
        var p1 = new Product { ProductId = 1, Name = "P1" };
        var p2 = new Product { ProductId = 2, Name = "P2" };
        var p3 = new Product { ProductId = 3, Name = "P3" };
        var cart = new Cart();

        // Act
        cart.AddItem(p1, 1);
        cart.AddItem(p2, 3);
        cart.AddItem(p3, 5);
        cart.AddItem(p2, 1);
        cart.RemoveItem(p2);

        // Assert
        Assert.Empty(cart.Lines.Where(x => x.Product == p2));
        Assert.Equal(2, cart.Lines.Count);
    }

    [Fact]
    public void Calculate_Cart_Total()
    {
        // Arrange - create a new cart
        var p1 = new Product { ProductId = 1, Name = "P1", Price = 100M };
        var p2 = new Product { ProductId = 2, Name = "P2", Price = 50M };
        var cart = new Cart();

        // Act
        cart.AddItem(p1, 1);
        cart.AddItem(p2, 3);
        cart.AddItem(p1, 3);
        var result = cart.ComputeTotalValue();

        Assert.Equal(550M, result);
    }

    [Fact]
    public void Can_Clear_Contents()
    {
        // Arrange
        var p1 = new Product { ProductId = 1, Name = "P1" };
        var p2 = new Product { ProductId = 2, Name = "P2" };
        var cart = new Cart();

        // Act
        cart.AddItem(p1, 2);
        cart.AddItem(p2, 1);
        cart.Clear();

        // Assert
        Assert.Empty(cart.Lines);
    }
}