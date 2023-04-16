namespace IrishNFTs.MVC.Models
{
    public class PaymentViewModel
    {

        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentCardName { get; set; }
        public string CardNum { get; set; }
        public string CardExp { get; set; }
        public string CardCvv { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool PaymentVoid { get; set; }

    }
}