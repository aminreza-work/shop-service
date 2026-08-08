
using ShopService.Enums;

public class CreateProductsDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ShopTitle { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished;
}
