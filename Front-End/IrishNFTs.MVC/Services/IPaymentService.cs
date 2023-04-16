using System.Threading.Tasks;
using IrishNFTs.MVC.Models;

namespace IrishNFTs.MVC.Services
{
    public interface IPaymentService
    {

        Task<PaymentViewModel> GetPaymentByOrderId(string orderId);

        Task<PaymentViewModel> CreatePaymentAsync(PaymentViewModel payment, int orderId);

        Task UpdatePaymentVoid(string paymentId, StringContent content);


    }

}