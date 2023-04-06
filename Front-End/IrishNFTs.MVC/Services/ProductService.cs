// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using IrishNFTs.MVC.Models;
// using System.Net.Http.Formatting;
// using Microsoft.AspNetCore.Mvc;

// namespace IrishNFTs.MVC.Services
// {
//     public class ProductService : IProductService
//     {
//         private readonly HttpClient _httpClient;

//         public ProductService(HttpClient httpClient)
//         {
//             _httpClient = httpClient;
//             _httpClient.BaseAddress = new Uri("http://localhost:5014");
//         }

//         [HttpGet]
//         public async Task<IEnumerable<Product>> GetAllProductsAsync()
//         {
//             try
//             {
//                 var response = await _httpClient.GetAsync("api/Product");
//                 Console.WriteLine(response);
//                 response.EnsureSuccessStatusCode();

//                 var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
//                 Console.WriteLine(products);
//                 return products ?? Enumerable.Empty<Product>();
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Error getting products from API: {ex.Message}");
//                 return Enumerable.Empty<Product>();
//             }
//         }
//     }
// }