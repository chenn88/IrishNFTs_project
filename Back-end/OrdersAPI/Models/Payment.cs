using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string? PaymentType { get; set; }
        public string? PaymentCardName { get; set; }
        public string? CardNum { get; set; }
        public string? CardExp { get; set; }
        public string? CardCvv { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool PaymentVoid { get; set; }
    }
}