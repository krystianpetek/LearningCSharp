using Moq;

namespace SimpleApp.Tests;

public class HomeControllerTests
{
    
    class FakeDataSource : IDataSource
    {
        public IEnumerable<Product> Products { get; }
        public FakeDataSource(Product[] data) => Products = data;
    }
    
    [Fact]
    public void IndexActionModelIsCompleteWithFakeClass()
    {
        #region Arrange

        Product[] testData = new Product[]
        {
            new Product() { Name = "P1", Price = 75.10M },
            new Product() { Name = "P2", Price = 120M },
            new Product() { Name = "P3", Price = 110M }
        };
        IDataSource data = new FakeDataSource(testData);
        var controller = new HomeController();
        controller.DataSource = data;

        #endregion

        #region Act

        var model = controller.Index().ViewData.Model as IEnumerable<Product>;

        #endregion

        #region Assert

        Assert.Equal(data.Products, model, Comparer.Get<Product>(
            (p1, p2) => p1?.Name == p2?.Name && p1?.Price == p2?.Price));

        #endregion
    }

    [Fact]
    public void IndexActionModelIsCompleteWithMoq()
    {
        #region Arrange

        Product[] testData = new Product[]
        {
            new Product() { Name = "P1", Price = 75.10M },
            new Product() { Name = "P2", Price = 120M },
            new Product() { Name = "P3", Price = 110M }
        };

        var mock = new Mock<IDataSource>();
        mock.SetupGet(m => m.Products).Returns(testData);

        var controller = new HomeController();
        controller.DataSource = mock.Object;

        #endregion

        #region Act

        var model = controller.Index().ViewData.Model as IEnumerable<Product>;

        #endregion

        #region Assert

        Assert.Equal(testData, model, Comparer.Get<Product>(
            (p1, p2) => p1?.Name == p2?.Name && p1?.Price == p2?.Price));
        
        mock.VerifyGet(m => m.Products, Times.Once);

        #endregion
    }
}