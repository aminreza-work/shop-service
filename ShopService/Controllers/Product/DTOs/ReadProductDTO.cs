namespace ShopService.Controllers.Product.DTOs
{
    public class ReadProductDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShopTitle { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
