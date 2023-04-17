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
    public class PaymentService : IPaymentService
    {
        private const string OrdersApiUrl = "http://ordersapi:5052/api/Payments";
        private readonly HttpClient _httpClient;


        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaymentViewModel> CreatePaymentAsync(PaymentViewModel payment, int orderId)
        {
            payment.OrderId = orderId;
            var response = await _httpClient.PostAsJsonAsync($"{OrdersApiUrl}", payment);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PaymentViewModel>();
        }

        public async Task<PaymentViewModel> GetPaymentByOrderId(string orderId)
        {
            var response = await _httpClient.GetAsync($"{OrdersApiUrl}/order/{orderId}");
            response.EnsureSuccessStatusCode();
            var paymentJson = await response.Content.ReadAsStringAsync();
            var payment = JsonConvert.DeserializeObject<PaymentViewModel>(paymentJson);
            return payment;
        }

        public async Task UpdatePaymentVoid(string paymentId, StringContent content)
        {
            var paymentVoidResponse = await _httpClient.PatchAsync($"{OrdersApiUrl}/{paymentId}/PaymentVoid", content);
            paymentVoidResponse.EnsureSuccessStatusCode();
        }

    }
}
