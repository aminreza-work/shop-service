using ShopService.Entities;

namespace ShopService.Repositories
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);


        void CreateProduct(string title, decimal price, int qty, bool isPublished)
        {
            
        }


    }
}
