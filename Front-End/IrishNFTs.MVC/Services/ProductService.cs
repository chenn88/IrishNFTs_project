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
        private const string ProductsApiUrl = "http://productsapi:5014/api/Product";
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductViewModel>> GetAllProducts(int pageNum = 1, int pageSize = 12)
        {
            var response = await _httpClient.GetAsync($"{ProductsApiUrl}?pageNum={pageNum}&pageSize={pageSize}");
            response.EnsureSuccessStatusCode();
            var productsJson = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(productsJson);
            if (products == null)
            {
                throw new Exception("Unable to deserialize products");
            }
            return products;


        }

        public async Task<int> GetProductsCount()
        {
            var response = await _httpClient.GetAsync($"{ProductsApiUrl}/count");
            response.EnsureSuccessStatusCode();
            var countJson = await response.Content.ReadAsStringAsync();
            int count = JsonConvert.DeserializeObject<int>(countJson);
            return count;
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"{ProductsApiUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var productJson = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductViewModel>(productJson);
            if (product == null)
            {
                throw new Exception("Unable to deserialize object");
            }
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
            if (createdProduct == null)
            {

                throw new Exception("An error occured when creating the product");

            }
            return createdProduct;
        }

        public async Task UpdateProductStock(string productId, StringContent content)
        {
            var inStockResponse = await _httpClient.PatchAsync($"{ProductsApiUrl}/{productId}/InStock", content);
            inStockResponse.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductTitle(string productId, StringContent content)
        {
            var titleResponse = await _httpClient.PatchAsync($"{ProductsApiUrl}/{productId}/Title", content);
            titleResponse.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductPrice(string productId, StringContent content)
        {
            var priceResponse = await _httpClient.PatchAsync($"{ProductsApiUrl}/{productId}/Price", content);
            priceResponse.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductDescription(string productId, StringContent content)
        {
            var descriptionResponse = await _httpClient.PatchAsync($"{ProductsApiUrl}/{productId}/Description", content);
            descriptionResponse.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductCategory(string productId, StringContent content)
        {
            var categoryResponse = await _httpClient.PatchAsync($"{ProductsApiUrl}/{productId}/Category", content);
            categoryResponse.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductImgUrl(string productId, StringContent content)
        {
            var imgUrlResponse = await _httpClient.PatchAsync($"{ProductsApiUrl}/{productId}/ImgUrl", content);
            imgUrlResponse.EnsureSuccessStatusCode();
        }
    }
}