using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using IrishNFTs.MVC.Services;

namespace IrishNFTs.MVC.Controllers
{
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

            var createOrder = await _orderService.CreateOrderAsync(order);
            return RedirectToAction("OrderConfirmation", new { id = createOrder.OrderId });

        }

        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var order = await _orderService.GetOrderById(id);
            return View(order);

        }

    }

}



