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

        public RepoResult CreateProduct(int shopId, string title, decimal price, int qty, bool isPublished)
        {

            // var validate = new ProductValidator(product);
            if(price < 1000)
                return new RepoResult(false, "قیمت محصول الگوی استانداردی ندارد");

            if (string.IsNullOrWhiteSpace(title))
                return new RepoResult(false, "عنوان محصول الگوی استانداردی ندارد");



            var shop = _db.Shops.SingleOrDefault(s => s.Id == shopId);
            if (shop == null)
                return new RepoResult(false, "فروشگاه یافت نشد!");

            if (!shop.IsVerified)
                return new RepoResult(false, "امکان ایجاد محصول برای این فروشگاه وجود ندارد!");

            

            title = title.Trim();

            var exist = _db.Products.Any(x => x.Title == title);
            if (exist)
                return new RepoResult(false, "این محصول تکراری است");

            //

            var product = new Product
            {
                Id =  Guid.NewGuid(),   
                ShopId = shopId,
                Title = title,
                Price = price,
                Qty = qty,
                IsPublished = isPublished,
                Status = ProductVerificationStatus.Pending,
                CreatedAt = DateTime.Now,
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            return new RepoResult(true, null);
        }

    

        public RepoResult<Product> GetProductById(Guid id)
        {
            var product = _db.Products
                .Include(a => a.Shop)
                .SingleOrDefault(x => x.Id == id);

            if (product is null)
                return new RepoResult<Product>(false, "محصول یافت نشد!", null);
            // Else
            return new RepoResult<Product>(true, null, product);
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

            return new RepoResult<IEnumerable<Product>>(true, null, products);
        }


    }
}
