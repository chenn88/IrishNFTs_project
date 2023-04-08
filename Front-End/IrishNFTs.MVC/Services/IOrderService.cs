using System.Threading.Tasks;
using IrishNFTs.MVC.Models;

namespace IrishNFTs.MVC.Services
{
    public interface IOrderService
    {
        Task<OrderViewModel> CreateOrderAsync(OrderViewModel order, string userId);
        Task<OrderViewModel> GetOrderById(int id);

        Task<IEnumerable<OrderViewModel>> GetOrdersByUserId(string userId);


    }
}