namespace IrishNFTs.MVC.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ImgUrl { get; set; }
        public bool InStock { get; set; }
    }
}