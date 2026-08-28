using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShopService.Entities;
using ShopService.Enums;
using ShopService.Migrations;
using ShopService.Shared.Objects;
using System.Net;

namespace ShopService.Repositories
{
    public class ShopRepo : IShop
    {
        private readonly AppDbContext _db;
        public ShopRepo(AppDbContext context)
        {
            _db = context;
        }

        public RepoResult CreateShop(int userId, string ShopTitle, bool IsVerified, string Address, string PhoneNumber)
        {
            // PascalCase   
            // camelCase
            // snake_case
            // kebab-case
            // field in class : _ + camelCase

            // CLEAN Architecture, SOLID Principles, DDD Pattern, CleanCode 

            var _ = new RepoResult();

            if (string.IsNullOrWhiteSpace(ShopTitle))
                return _.Error("اسم الگوی استاندارد ندارد");

            ShopTitle = ShopTitle.Trim();

            if (!IsVerified)
                return new RepoResult(false, "حساب کاربری غیر فعال است");

            if (ShopTitle.Length <= 4)
                return new RepoResult(false, "طول اسم کمتر از حد مجاز");
            if (ShopTitle.Length > 10)
                return new RepoResult(false, "طول اسم بیش از حد مجاز");


            var shopExist = _db.Shops.Any(x => x.Title == ShopTitle);
            if (shopExist)
                return new RepoResult(false, "فروشگاه تکراری است.");


            var shop = new Shop
            {
                Id = userId,
                Title = ShopTitle,
                IsVerified = IsVerified,
                Address = Address,
                PhoneNumber = PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            _db.Shops.Add(shop);
            _db.SaveChanges();
            return _.OK();

        }
        public RepoResult<Shop> ReadShop(int userId)
        {
            var _ = new RepoResult<Shop>();

            var shop = _db.Shops
                .SingleOrDefault(x => x.Id == userId);

            if (shop == null)
                return _.Error("فروشگاه یافت نشد");

            return _.OK(shop);
        }

        public RepoResult<IEnumerable<Shop>> SearchShop()
        {
            //var pageSize = 20;

            var shops = _db.Shops
                .OrderByDescending(a => a.CreatedAt);


            //switch (sortType)
            //{
            //    case "ByDate":
            //        shops = shops.OrderByDescending(a => a.CreatedAt);
            //        break;
            //    case "ByTitle":
            //        shops = shops.OrderByDescending(a => a.Title);
            //        break;
            //    default:
            //        break;
            //}

            //shops = shops.Skip(0).Take(pageSize);


            return new RepoResult<IEnumerable<Shop>>(true, null, shops);
        }
        public RepoResult UpdateShop(int userId, string Address, string ShopTitle, string PhoneNumber)

        {
            var shop = _db.Shops
                .SingleOrDefault(x => x.Id == userId);
            if (shop == null)
                return new RepoResult(false, "فروشگاه پیدا نشد ");
            if (string.IsNullOrWhiteSpace(ShopTitle))
                return new RepoResult(false, "عنوان فروشگاه نا معتبر است");
            if (string.IsNullOrWhiteSpace(Address))
                return new RepoResult(false, "ادرس نا معتبر است");
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                return new RepoResult(false, "شماره نا معتبر");

            shop.ShopTitle = ShopTitle;
            shop.Address = Address;
            shop.PhoneNumber = PhoneNumber;

            _db.SaveChanges();
            return new RepoResult(true, null);
        }
    }
}
