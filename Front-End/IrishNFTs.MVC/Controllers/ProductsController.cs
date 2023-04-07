using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using Newtonsoft.Json;
using IrishNFTs.MVC.Services;

namespace IrishNFTs.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        public async Task<ActionResult> ProductDetails(int id)
        {
            var product = await _productService.GetProductById(id);
            return View("ProductDetails", product);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductById(id);
            return RedirectToAction("Index");
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _productService.CreateProduct(product);
            return RedirectToAction("Products");
        }

        public async Task<ActionResult> EditProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _productService.UpdateProduct(product);
            return RedirectToAction("Products");
        }
    }
}