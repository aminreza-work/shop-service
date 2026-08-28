using ShopService.Entities;
using ShopService.Shared.Objects;

namespace ShopService.Repositories
{
    public interface IProduct
    {
        //CRUD (Read, Create, Update, Delete)
        // Search => GetList(Filter)
        // Read => GetItemById
        // Create => CreateItem
        // Update => UpdateItem, UpdateField
        // Delete => X

        // Product (Admin, Seller, Buyer, Public)
        // 

        RepoResult<IEnumerable<Product>> GetProducts(); // Search
        RepoResult<Product> GetProductById(Guid id); // Read
        RepoResult CreateProduct(int shopId, string title, decimal price, int qty, bool isPublished); //Create
        RepoResult UpdateProduct (Guid id ,int Qty,decimal Price);
    }
}
