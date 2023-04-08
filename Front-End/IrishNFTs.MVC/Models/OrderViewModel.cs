namespace IrishNFTs.MVC.Models
{
    public class OrderViewModel
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public bool OrderCancellation { get; set; }


    }
}