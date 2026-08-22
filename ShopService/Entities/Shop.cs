using ShopService.Enums;

namespace ShopService.Entities
{
    public class Shop
    {
        public Shop()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PhoneNumber { get; set; }
        public string Address {  get; set; }
        public ShopVerificationStatus Status { get; set; }


        public IEnumerable<Product> Products { get; set; }
    }
}

