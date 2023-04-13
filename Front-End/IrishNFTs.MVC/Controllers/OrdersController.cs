using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using IrishNFTs.MVC.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace IrishNFTs.MVC.Controllers
{

    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrdersController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderSummary(int id)
        {
            var product = await _productService.GetProductById(id);
            return View(product);

        }

        [HttpPost]

        public async Task<IActionResult> CompleteOrder(OrderViewModel order)

        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?.ToString();
            var orderDate = DateTime.Now;

            var newOrder = new OrderViewModel
            {
                ProductId = order.ProductId,
                OrderTotal = order.OrderTotal,
                OrderDate = orderDate,
                OrderCancellation = false
            };

            var createOrder = await _orderService.CreateOrderAsync(newOrder, userId);
            return RedirectToAction("OrderConfirmation", new { id = createOrder.OrderId });

        }

        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = await _orderService.GetOrderById(id);
            return View(order);

        }

        public async Task<IActionResult> MyOrders()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orders = await _orderService.GetOrdersByUserId(userId);
            return View(orders);
        }
    }

}



