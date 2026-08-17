
using ShopService.Enums;

public class CreateProductDTO
{
    public string Title { get; set; }
    public int ShopId { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished { get; set; }
}
