using ShopService.Entities;

namespace ShopService.Repositories
{
    public interface IProduct
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
    }
}
