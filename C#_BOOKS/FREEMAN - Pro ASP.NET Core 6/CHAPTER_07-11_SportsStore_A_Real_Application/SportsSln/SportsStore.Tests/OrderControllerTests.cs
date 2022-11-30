namespace SportsStore.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void Cannot_Checkout_Empty_Cart()
        {
            // arrange
            Mock<IOrderRepository> repository = new Mock<IOrderRepository>();
            
            Cart cart = new Cart();            
            Order order = new Order();

            OrderController controller = new OrderController(repository.Object, cart);

            // act
            ViewResult? viewResult = controller.Checkout(order) as ViewResult;

            // assert 1 - check that the order hasn't been stored
            repository.Verify(repoo => repoo.SaveOrder(It.IsAny<Order>()), Times.Never);

            // assert 2 - check that the method is returning the default view
            Assert.True(string.IsNullOrEmpty(viewResult?.ViewName));

            // assert 3 - check that i am passing an invalid model to the view
            Assert.False(viewResult?.ViewData.ModelState.IsValid);
        }

        [Fact] 
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            // arrange
            Mock<IOrderRepository> repository = new Mock<IOrderRepository>();

            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            Order order = new Order();

            OrderController orderController = new OrderController(repository.Object, cart);

            orderController.ViewData.ModelState.AddModelError("error", "error");

            // act - try to checkout
            ViewResult? viewResult = orderController.Checkout(order) as ViewResult;

            // assert 1 - check that the order hasn't been passed stored
            repository.Verify(repo => repo.SaveOrder( It.IsAny<Order>()),Times.Never);

            // assert 2 - check that the method is returning the default value
            Assert.True(string.IsNullOrEmpty(viewResult?.ViewName));
            
            // assert 3 - check that i am passing an invalid model to the view
            Assert.False(viewResult?.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void Can_Checkout_And_Submit_Order()
        {
            // arrange
            Mock<IOrderRepository> repository = new Mock<IOrderRepository>();

            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            Order order = new Order();

            OrderController orderController = new OrderController(repository.Object, cart);

            // act
            RedirectToPageResult? redirectResult = orderController.Checkout(order) as RedirectToPageResult;

            // assert 1 - check that the order has been stored
            repository.Verify(repo => repo.SaveOrder( It.IsAny<Order>()),Times.Once);

            // assert 2 - check that the method is redirectring to the completed action
            Assert.Equal("/Completed", redirectResult?.PageName);


        }
    }
}
