using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IrishNFTs.MVC.Models;
using IrishNFTs.MVC.Controllers;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace IrishNFTs.MVC.Services
{
    public class OrderService : IOrderService
    {
        private const string OrdersApiUrl = "http://ordersapi:5052/api/Orders";
        private readonly HttpClient _httpClient;


        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderViewModel> CreateOrderAsync(OrderViewModel order, string userId)
        {
            order.UserId = userId;
            var response = await _httpClient.PostAsJsonAsync($"{OrdersApiUrl}", order);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OrderViewModel>();
            if (result == null)
            {
                throw new Exception("An error occured when creating the order");
            }
            return result;
        }

        public async Task<OrderViewModel> GetOrderById(int id)
        {
            var response = await _httpClient.GetAsync($"{OrdersApiUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var orderJson = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderViewModel>(orderJson);
            if (order == null)
            {

                throw new Exception("An error occured - Order not found");

            }
            return order;
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrdersByUserId(string userId)
        {
            var response = await _httpClient.GetAsync($"{OrdersApiUrl}/user/{userId}");
            response.EnsureSuccessStatusCode();
            var ordersJson = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<IEnumerable<OrderViewModel>>(ordersJson);
            if (orders == null)
            {
                throw new Exception("An error has occured - no orders found");
            }

            return orders;
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var OrderCancellation = true;
            var orderCancellationStatus = new StringContent(JsonConvert.SerializeObject(OrderCancellation), Encoding.UTF8, "application/json");
            var orderCancellationResponse = await _httpClient.PatchAsync($"{OrdersApiUrl}/{orderId}/OrderCancellation", orderCancellationStatus);
            orderCancellationResponse.EnsureSuccessStatusCode();

        }

    }



}




