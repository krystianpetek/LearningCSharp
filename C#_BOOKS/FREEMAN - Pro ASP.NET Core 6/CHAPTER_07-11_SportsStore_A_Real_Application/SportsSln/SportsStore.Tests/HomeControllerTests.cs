using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;

namespace SportsStore.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Can_Use_Repository()
    {
        var mockRepo = new Mock<IStoreRepository>();
        mockRepo.Setup(m => m.Products).Returns(
            new List<Product>
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "P1"
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "P2"
                }
            }.AsQueryable<Product>());

        var controller = new HomeController(mockRepo.Object);
        IEnumerable<Product>? result = (controller.Index() as ViewResult)?.Model as IEnumerable<Product>;

        var prodArray = result?.ToArray() ?? Array.Empty<Product>();
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P1", prodArray[0].Name);
        Assert.Equal("P2", prodArray[1].Name);
    }
}
