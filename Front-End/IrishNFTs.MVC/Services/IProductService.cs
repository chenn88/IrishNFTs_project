using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IrishNFTs.MVC.Models;

namespace IrishNFTs.MVC.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> GetProductById(int id);
        Task<ProductViewModel> CreateProduct(ProductViewModel product);
        // Task UpdateProduct(ProductViewModel product);
        Task UpdateProductStock(string productId, StringContent content);
        Task UpdateProductTitle(string productId, StringContent content);
        Task UpdateProductPrice(string productId, StringContent content);
        Task UpdateProductDescription(string productId, StringContent content);
        Task UpdateProductCategory(string productId, StringContent content);
        Task UpdateProductImgUrl(string productId, StringContent content);
        Task DeleteProductById(int id);
    }
}