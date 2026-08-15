using Microsoft.EntityFrameworkCore;
using ShopService.Entities;
using ShopService.Enums;
using ShopService.Shared.Objects;

namespace ShopService.Repositories
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _db;
        public ProductRepo(AppDbContext context)
        {
            _db = context;
        }

        public RepoResult CreateProduct(string title, decimal price, int qty, bool isPublished)
        {

            // var validate = new ProductValidator(product);

            if (price < 1000)
                return new RepoResult(false, "قیمت محصول الگوی استانداردی ندارد");

            if (string.IsNullOrWhiteSpace(title))
                return new RepoResult(false, "عنوان محصول الگوی استانداردی ندارد");

            title = title.Trim();

            var exist = _db.Products.Any(x => x.Title == title);
            if (exist)
                return new RepoResult(false, "این محصول تکراری است");

            //
            
            var product = new Product
            {
                Title = title,
                Price = price,
                Qty = qty,
                IsPublished = isPublished,
                Status = ProductVerificationStatus.Pending,
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            return new RepoResult(true, null);
        }

        public RepoResult<Product> GetProductById(int id)
        {
            var products = _db.Products
                .Include(a => a.Shop)
                .Where(a => a.IsPublished &&
                            a.Status == ProductVerificationStatus.Approved)
                .OrderByDescending(a => a.CreatedAt);
            throw new NotImplementedException("Bad Request");
        }

        public RepoResult<IEnumerable<Product>> GetProducts()
        {
            var products = _db.Products
                .Include(x => x.Shop)
                .Where(x => x.IsPublished &&
                            x.Status == ProductVerificationStatus.Approved)
                .OrderByDescending(x => x.CreatedAt);


            //var products1 = _db.Products
            //    .Where(x => x.IsPublished && (x.Status == ProductVerificationStatus.Pending || x.Status == ProductVerificationStatus.Rejected));

            return new RepoResult<IEnumerable<Product>>(true,null, products);
        }

    }
}
