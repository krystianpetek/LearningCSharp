using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Interface;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository orderRepository, Cart cartService)
        {
            _orderRepository = orderRepository;
            _cart = cartService;
        }
        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count < 1)
                ModelState.AddModelError("", "Sorry your cart is empty!");

            if(ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToList();
                _orderRepository.SaveOrder(order);

                _cart.Clear();

                return RedirectToPage("/Completed", new { orderId = order.OrderId });
            }

            return View();
        }
    }
}
