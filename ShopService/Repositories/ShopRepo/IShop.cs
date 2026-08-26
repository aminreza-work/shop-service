using ShopService.Entities;
using ShopService.Shared.Objects;


namespace ShopService.Repositories
{
    public interface IShop
    {
        RepoResult<IEnumerable<Shop>> SearchShop(); // Search
        RepoResult<Shop> ReadShop(int userId); // Read
        RepoResult CreateShop(int userId, string ShopTitle, bool IsVerified, string Address, string PhoneNumber);
    }

}