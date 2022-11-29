using SportsStore.Data;

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
                new() { ProductId = 1, Name = "P1" },
                new() { ProductId = 2, Name = "P2" }
            }.AsQueryable());

        var controller = new HomeController(mockRepo.Object);
        var result = (controller.Index(null) as ViewResult)?.Model as ProductsListViewModel ??
                     new ProductsListViewModel();

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
            .Returns(new[]
            {
                new() { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" }
            }.AsQueryable());

        var controller = new HomeController(mock.Object) { PageSize = 3 };
        var result = (controller.Index(null, 2) as ViewResult)?.ViewData.Model as ProductsListViewModel ??
                     new ProductsListViewModel();

        var prodArray = result.Products.ToArray();
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P4", prodArray[0].Name);
        Assert.Equal("P5", prodArray[1].Name);
    }

    [Fact]
    public void Can_Send_Pagination_View_Model()
    {
        var mock = new Mock<IStoreRepository>();
        mock.Setup(m => m.Products).Returns(new[]
        {
            new() { ProductId = 1, Name = "P1" },
            new Product { ProductId = 2, Name = "P2" },
            new Product { ProductId = 3, Name = "P3" },
            new Product { ProductId = 4, Name = "P4" },
            new Product { ProductId = 5, Name = "P5" }
        }.AsQueryable());

        var controller = new HomeController(mock.Object) { PageSize = 3 };
        var result = (controller.Index(null, 2) as ViewResult)?.ViewData.Model as ProductsListViewModel ??
                     new ProductsListViewModel();

        var pageInfo = result.PagingInfo;
        Assert.Equal(2, pageInfo.CurrentPage);
        Assert.Equal(5, pageInfo.TotalItems);
        Assert.Equal(2, pageInfo.TotalPages);
        Assert.Equal(3, pageInfo.ItemsPerPage);
    }

    [Fact]
    public void Can_Filter_Product()
    {
        var mock = new Mock<IStoreRepository>();
        mock.Setup(x => x.Products)
            .Returns(new[]
            {
                new() { ProductId = 1, Name = "P1", Category = "Cat1" },
                new Product { ProductId = 2, Name = "P2", Category = "Cat2" },
                new Product { ProductId = 3, Name = "P3", Category = "Cat1" },
                new Product { ProductId = 4, Name = "P4", Category = "Cat2" },
                new Product { ProductId = 5, Name = "P5", Category = "Cat3" }
            }.AsQueryable());

        var controller = new HomeController(mock.Object) { PageSize = 3 };

        var result = ((controller.Index("Cat2") as ViewResult)?.ViewData.Model as ProductsListViewModel ??
                      new ProductsListViewModel())
            .Products.ToArray();

        Assert.Equal(2, result.Length);
        Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
        Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
    }

    [Fact]
    public void Generate_Category_Specific_Product_Count()
    {
        var mock = new Mock<IStoreRepository>();
        mock.Setup(m => m.Products).Returns(new[]
        {
            new() { ProductId = 1, Name = "P1", Category = "Cat1" },
            new Product { ProductId = 2, Name = "P2", Category = "Cat2" },
            new Product { ProductId = 3, Name = "P3", Category = "Cat1" },
            new Product { ProductId = 4, Name = "P4", Category = "Cat2" },
            new Product { ProductId = 5, Name = "P5", Category = "Cat3" }
        }.AsQueryable());

        var controller = new HomeController(mock.Object);
        controller.PageSize = 3;

        Func<ViewResult, ProductsListViewModel?> GetModel = result => result.Model as ProductsListViewModel;

        var cat1 = GetModel(controller.Index("Cat1") as ViewResult)?.PagingInfo.TotalItems;
        var cat2 = GetModel(controller.Index("Cat2") as ViewResult)?.PagingInfo.TotalItems;
        var cat3 = GetModel(controller.Index("Cat3") as ViewResult)?.PagingInfo.TotalItems;
        var catAll = GetModel(controller.Index(null) as ViewResult)?.PagingInfo.TotalItems;

        Assert.Equal(2, cat1);
        Assert.Equal(2, cat2);
        Assert.Equal(1, cat3);
        Assert.Equal(5, catAll);
    }
}