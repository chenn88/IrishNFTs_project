using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using Newtonsoft.Json;
using System.Text;
using IrishNFTs.MVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace IrishNFTs.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index(int? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 12;
            var products = await _productService.GetAllProducts(pageNum, pageSize, true); // Pass true for inStockOnly
            int totalItemCount = await _productService.GetProductsCount();
            ViewBag.TotalItemCount = totalItemCount;
            ViewBag.PageNumber = pageNum;
            return View(products);
        }

        public async Task<ActionResult> ProductsAdmin(int? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 12;
            var products = await _productService.GetAllProducts(pageNum, pageSize, null);
            int totalItemCount = await _productService.GetProductsCount();
            ViewBag.TotalItemCount = totalItemCount;
            ViewBag.PageNumber = pageNum;
            return View(products);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductById(id);
            return RedirectToAction("ProductsAdmin");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateProduct()
        {

            return RedirectToAction("ProductsAdmin");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                product.InStock = true;
                await _productService.CreateProduct(product);

            }


            return RedirectToAction("ProductsAdmin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            return View(product);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductTitle(int id, string title)
        {

            var content = new StringContent(JsonConvert.SerializeObject(title), Encoding.UTF8, "application/json");
            await _productService.UpdateProductTitle(id.ToString(), content);
            return RedirectToAction("ProductsAdmin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductPrice(int id, string price)
        {

            var content = new StringContent(JsonConvert.SerializeObject(price), Encoding.UTF8, "application/json");
            await _productService.UpdateProductPrice(id.ToString(), content);
            return RedirectToAction("ProductsAdmin");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductDescription(int id, string description)
        {

            var content = new StringContent(JsonConvert.SerializeObject(description), Encoding.UTF8, "application/json");
            await _productService.UpdateProductDescription(id.ToString(), content);
            return RedirectToAction("ProductsAdmin");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductCategory(int id, string category)
        {

            var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            await _productService.UpdateProductCategory(id.ToString(), content);
            return RedirectToAction("ProductsAdmin");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductImgUrl(int id, string imgUrl)
        {

            var content = new StringContent(JsonConvert.SerializeObject(imgUrl), Encoding.UTF8, "application/json");
            await _productService.UpdateProductImgUrl(id.ToString(), content);
            return RedirectToAction("ProductsAdmin");
        }
    }
}