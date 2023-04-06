

namespace OrdersAPI.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderTotal { get; set; }
        public bool OrderCancellation { get; set; }
    }
}