
using ShopService.Enums;

public class CreateProductDTO
{
    public string Title { get; set; }
    //public string ShopId { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished { get; set; }
}
