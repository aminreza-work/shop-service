using System.Collections;

namespace ShopService.Entities
{
    public class Shop
    {
        public Shop()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PhoneNumber { get; set; }

        public string Title { get; set; }




        public IEnumerable<Product> Products { get; set; }
    }
}
