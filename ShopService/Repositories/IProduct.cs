using ShopService.Entities;
using ShopService.Shared.Objects;

namespace ShopService.Repositories
{
    public interface IProduct
    {
        RepoResult<IEnumerable<Product>> GetProducts();
        RepoResult<Product> GetProductById(int id);


        RepoResult CreateProduct(string title, decimal price, int qty, bool isPublished);
        object GetProductById(Guid id);
    }
}
