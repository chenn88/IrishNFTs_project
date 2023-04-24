namespace IrishNFTs.MVC.Models
{
    public class OrderDetailViewModel
    {

        public IEnumerable<OrderProductViewModel>? OrderProductList { get; set; }

        public OrderDetailViewModel()
        {
            OrderProductList = new List<OrderProductViewModel>();
        }
    }
}

