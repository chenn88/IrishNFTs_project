using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using Newtonsoft.Json;

namespace IrishNFTs.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private const string ProductsApiUrl = "http://localhost:5014/api/Product";

        public async Task<ActionResult> Products()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(ProductsApiUrl);
                var productsJson = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(productsJson);
                return View("Products", products);
            }
        }
    }
}