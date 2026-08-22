using ShopService.Entities;
using ShopService.Shared.Objects;


namespace ShopService.Repositories
{
    public interface IShop
    {
    RepoResult<IEnumerable<Shop>> SearchShop(); // Search
    RepoResult<Shop> ReadShop(Userid); // Read
    RepoResult CreateShop(int Userid, string ShopTitle, bool IsVerified, string Address, int PhoneNumber);
    }

}