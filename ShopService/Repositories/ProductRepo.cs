using ShopService.Entities;

namespace ShopService.Repositories
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _db;
        public ProductRepo(AppDbContext context)
        {
            _db = context;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            var products = _db.Products.ToList();
            return products;
        }
    }
}
