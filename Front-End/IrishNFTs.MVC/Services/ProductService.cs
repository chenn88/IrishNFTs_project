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
    public class ProductService : IProductService
    {
        private const string ProductsApiUrl = "http://localhost:5014/api/Product";
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync(ProductsApiUrl);
            response.EnsureSuccessStatusCode();
            var productsJson = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(productsJson);
            return products;
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"{ProductsApiUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var productJson = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductViewModel>(productJson);
            return product;
        }

        public async Task DeleteProductById(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ProductsApiUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel product)
        {
            var productJson = JsonConvert.SerializeObject(product);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ProductsApiUrl, content);
            response.EnsureSuccessStatusCode();
            var createdProductJson = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<ProductViewModel>(createdProductJson);
            return createdProduct;
        }

        public async Task UpdateProduct(ProductViewModel product)
        {
            var productJson = JsonConvert.SerializeObject(product);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{ProductsApiUrl}/{product.ProductId}", content);
            response.EnsureSuccessStatusCode();
        }
    }
}