using Microsoft.EntityFrameworkCore;
using ShopService.Entities;
using ShopService.Enums;

namespace ShopService.Repositories
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _db;
        public ProductRepo(AppDbContext context)
        {
            _db = context;
        }

        public void CreateProduct(string title, decimal price, int qty, bool isPublished)
        {
            var product     = new Product
                {
                Title = title,
                Price = price,
                Qty = qty,
                IsPublished = isPublished,
                Status = ProductVerificationStatus.Pending,
            };




        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _db.Products
                .Include(x=>x.Shop)
                .Where(x => x.IsPublished &&
                            x.Status == ProductVerificationStatus.Approved)
                .OrderByDescending(x => x.CreatedAt);

            //var products1 = _db.Products
            //    .Where(x => x.IsPublished && (x.Status == ProductVerificationStatus.Pending || x.Status == ProductVerificationStatus.Rejected));

            return products;
        }

    }
}
