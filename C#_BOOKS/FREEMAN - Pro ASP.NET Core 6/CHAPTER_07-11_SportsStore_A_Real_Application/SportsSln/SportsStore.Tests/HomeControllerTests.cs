using Castle.Components.DictionaryAdapter.Xml;
using SportsStore.ViewModels;

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
                new Product() { ProductId = 1, Name = "P1" },
                new Product() { ProductId = 2, Name = "P2" }
            }.AsQueryable<Product>());

        var controller = new HomeController(mockRepo.Object);
        var result = (controller.Index() as ViewResult)?.Model as ProductsListViewModel ?? new();

        var prodArray = result.Products.ToArray();
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P1", prodArray[0].Name);
        Assert.Equal("P2", prodArray[1].Name);
    }

    [Fact]
    public void Can_Paginate()
    {
        var mock = new Mock<IStoreRepository>();
        mock.Setup(mock => mock.Products)
            .Returns(new Product[] {
                new Product() { ProductId = 1, Name = "P1" },
                new Product() { ProductId = 2, Name = "P2" },
                new Product() { ProductId = 3, Name = "P3" },
                new Product() { ProductId = 4, Name = "P4" },
                new Product() { ProductId = 5, Name = "P5" }
            }.AsQueryable<Product>());

        var controller = new HomeController(mock.Object) { PageSize = 3 };
        var result = (controller.Index(2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var prodArray = result.Products.ToArray();        
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P4", prodArray[0].Name);
        Assert.Equal("P5", prodArray[1].Name);
    }

    [Fact]
    public void Can_Send_Pagination_View_Model()
    {
        var mock = new Mock<IStoreRepository>();
        mock.Setup(m => m.Products).Returns(new Product[] {
            new Product() { ProductId = 1, Name = "P1" },
            new Product() { ProductId = 2, Name = "P2" },
            new Product() { ProductId = 3, Name = "P3" },
            new Product() { ProductId = 4, Name = "P4" },
            new Product() { ProductId = 5, Name = "P5" }
        }.AsQueryable<Product>());

        var controller = new HomeController(mock.Object) { PageSize = 3 };
        var result = (controller.Index(2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var pageInfo = result.PagingInfo;
        Assert.Equal(2, pageInfo.CurrentPage);
        Assert.Equal(5, pageInfo.TotalItems);
        Assert.Equal(2, pageInfo.TotalPages);
        Assert.Equal(3, pageInfo.ItemsPerPage);
    }
}
