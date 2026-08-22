using Microsoft.EntityFrameworkCore;
using ShopService.Entities;
using ShopService.Enums;
using ShopService.Shared.Objects;

namespace ShopService.Repositories
{
    public class ShopRepo : IShop
    {
        private readonly AppDbContext _db;
        public ShopRepo(AppDbContext context)
        {
            _db = context;
        }

        public RepoResult CreateShop(int Userid, string ShopTitle, bool IsVerified, string Address, string PhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(ShopTitle))
                return new RepoResult(false, "اسم الگوی استاندارد ندارد");
            if (!IsVerified)
                return new RepoResult(false ,"حساب کاربری غیر فعال است");
            if (ShopTitle.Length <= 4)
                return new RepoResult(false , "طول اسم کمتر از حد مجاز");
            if (ShopTitle.Length > 10)
                return new RepoResult(false , "طول اسم بیش از حد مجاز");
            

           // var exist _db.Shops.Any (x => x.shopTitle == ShopTitle);
           // if (exist)
               // return new RepoResult(false , "فروشگاه تکراری است.");

            var shop = new Shop
            {
                Id = Userid ,
                Title = ShopTitle,
                IsVerified = IsVerified,
                Address = Address,
                PhoneNumber = PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            _db.Shops.Add(shop);
            _db.SaveChanges();
            return new RepoResult(true, null);

        }
        public RepoResult<Shop> ReadShop(int Userid)
        {

            var shop = _db.Shops 
                .SingleOrDefault(x => x.Id == Userid);
            if (shop == null)
                return new RepoResult<Shop>(false ,"فروشگاه یافت نشد",shop);
                return new RepoResult<Shop>(true, null, shop);


        }

        public RepoResult<IEnumerable<Shop>> SearchShop()
        {
            var shops = _db.Shops
                .Where(a => a.IsVerified &&
                a.Status == ShopVerificationStatus.Approved)
                .OrderByDescending(a => a.CreatedAt);
            return new RepoResult<IEnumerable<Shop>>(true, null, shops);
        }
    }
}