using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Data;

namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            var mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns(new[]
            {
            new()
            {
                ProductId = 1, Name = "P1",
                Category = "Apples"
            },
            new Product
            {
                ProductId = 2, Name = "P2",
                Category = "Apples"
            },
            new Product
            {
                ProductId = 3, Name = "P3",
                Category = "Plums"
            },
            new Product
            {
                ProductId = 4, Name = "P4",
                Category = "Oranges"
            }
        }.AsQueryable());

            var target = new NavigationMenuViewComponent(mock.Object);

            // Act
            var results = (target.Invoke() as ViewViewComponentResult)?.ViewData?.Model as IEnumerable<string> ??
                          Enumerable.Empty<string>();

            // Assert
            Assert.True(new[] { "Apples", "Oranges", "Plums" }.SequenceEqual(results));
        }


        [Fact]
        public void Indicates_Selected_Category()
        {
            var categoryToSelect = "Apples";
            var mock = new Mock<IStoreRepository>();

            var target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext.ViewContext.RouteData = new RouteData();
            target.RouteData.Values["category"] = categoryToSelect;

            var result = (target.Invoke() as ViewViewComponentResult)?.ViewData?["SelectedCategory"] as string;
            Assert.Equal(categoryToSelect, result);
        }

    }
}
