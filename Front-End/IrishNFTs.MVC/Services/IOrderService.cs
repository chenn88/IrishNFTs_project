using System.Threading.Tasks;
using IrishNFTs.MVC.Models;

namespace IrishNFTs.MVC.Services
{
    public interface IOrderService
    {
        Task<OrderViewModel> CreateOrderAsync(OrderViewModel order);
        Task<OrderViewModel> GetOrderById(int id);
    }
}