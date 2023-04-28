using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using IrishNFTs.MVC.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;


namespace IrishNFTs.MVC.Controllers
{

    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        private readonly IPaymentService _paymentService;

        public OrdersController(IProductService productService, IOrderService orderService, IPaymentService paymentService)
        {
            _productService = productService;
            _orderService = orderService;
            _paymentService = paymentService;
        }

        public async Task<IActionResult> OrderSummary(int id)
        {
            var product = await _productService.GetProductById(id);
            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(OrderViewModel order, PaymentViewModel payment)

        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?.ToString();
            if (userId == null)
            {
                return BadRequest("User ID is null");
            }
            var orderDate = DateTime.Now;

            var newOrder = new OrderViewModel
            {
                ProductId = order.ProductId,
                OrderTotal = order.OrderTotal,
                OrderDate = orderDate,
                OrderCancellation = false
            };

            var createOrder = await _orderService.CreateOrderAsync(newOrder, userId);

            var newPayment = new PaymentViewModel
            {
                OrderId = createOrder.OrderId,
                PaymentType = payment.PaymentType,
                PaymentCardName = payment.PaymentCardName,
                CardNum = payment.CardNum,
                CardExp = payment.CardExp,
                CardCvv = payment.CardCvv,
                PaymentAmount = order.OrderTotal,
                PaymentVoid = false
            };

            await _paymentService.CreatePaymentAsync(newPayment, createOrder.OrderId);


            var inStock = false;
            var inStockStatus = new StringContent(JsonConvert.SerializeObject(inStock), Encoding.UTF8, "application/json");
            await _productService.UpdateProductStock(order.ProductId.ToString(), inStockStatus);
            return RedirectToAction("OrderConfirmation", new { id = createOrder.OrderId });

        }


        public async Task<IActionResult> CancelOrder(int id)

        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {

                return NotFound();
            }

            await _orderService.CancelOrderAsync(id);

            var productId = order.ProductId.ToString();
            var orderId = order.OrderId.ToString();

            var inStock = true;
            var inStockStatus = new StringContent(JsonConvert.SerializeObject(inStock), Encoding.UTF8, "application/json");
            await _productService.UpdateProductStock(order.ProductId.ToString(), inStockStatus);
            var paymentVoid = true;

            var payment = await _paymentService.GetPaymentByOrderId(orderId);
            var paymentId = payment.PaymentId;



            var paymentVoidStatus = new StringContent(JsonConvert.SerializeObject(paymentVoid), Encoding.UTF8, "application/json");
            await _paymentService.UpdatePaymentVoid(paymentId.ToString(), paymentVoidStatus);

            return RedirectToAction("MyOrders");

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

            if (userId == null)
            {

                return BadRequest();
            }

            var orders = await _orderService.GetOrdersByUserId(userId);

            var orderProductList = new List<OrderProductViewModel>();
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    var product = await _productService.GetProductById(order.ProductId);

                    orderProductList.Add(new OrderProductViewModel
                    {
                        Order = order,
                        Product = product
                    });
                }

                var viewModel = new OrderDetailViewModel
                {
                    OrderProductList = orderProductList
                };

                return View(viewModel);
            }

            else
            {
                return View();
            }
        }

    }

}



