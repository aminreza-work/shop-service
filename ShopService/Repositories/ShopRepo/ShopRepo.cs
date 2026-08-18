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

        public RepoResult CreateShop(int Userid, string ShopTitle, bool IsVerified, string Address, int PhoneNumber)
        {
            if (string.Lenght <= 4(ShopTitle))
                return new RepoResult(false "طول اسم کمتر از حد مجاز");
            if (string.IsNullOrWhiteSpace | (ShopTitle))
                return new RepoResult(false "اسم الگوی استاندارد ندارد");
            if (string.Lenght >= 10(ShopTitle))
                return new RepoResult(false "طول اسم بیش از حد مجاز");

            if (!IsVerified)
                return new RepoResult("حساب کاربری غیر فعال است");

            var exist _db.Shops.Any(x => x.Title == title);
            if (exist)
                return new RepoResult("فروشگاه تکراری است.");

            var shop = new Shop
            {
                id = Userid,
                Title = ShopTitle,
                IsVerified = IsVerified,
                Address = Address,
                PhoneNumber = PhoneNumber,
            };

            _db.Shops.Add(shop);
            _db.SaveChanges();
            return new RepoResult(true, null);

        }
        public RepoResult<Shop> GetShopByid(User id)
        {

            var shop = _db.Shops
                .Include(a => a.Title)
                .SingleOrDefault(x => x.Id == id);
            if (shop == null)
                return new RepoResult<Shop>(false "فروشگاه یافت نشد");
            return new RepoResult<Shop>(true, null, shop);


        }

        public RepoResult<IEnumerable<Shop>> GetShops()
        {
            var shops = _db.Shops
                .Include(a => a.Shop)..Where(a => a.IsVerified &&
                                                 a.Status == ShopVerificationStatus.Approved)
                .OrderByDescending(a => a.CreatedAt);

            return new RepoResult<IEnumerable<Shop>>(true, null, shops);
        }
    }
}