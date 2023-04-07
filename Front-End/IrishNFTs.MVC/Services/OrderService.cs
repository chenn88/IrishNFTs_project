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
        private const string OrdersApiUrl = "http://localhost:5052/api/Orders";
        private readonly HttpClient _httpClient;


        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderViewModel> CreateOrderAsync(OrderViewModel order)
        {
            var response = await _httpClient.PostAsJsonAsync($"{OrdersApiUrl}", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OrderViewModel>();
        }

        public async Task<OrderViewModel> GetOrderById(int id)
        {
            var response = await _httpClient.GetAsync($"{OrdersApiUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var orderJson = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderViewModel>(orderJson);
            return order;
        }


    }



}




