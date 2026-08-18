using ShopService.Enums;

namespace ShopService.Controllers.Product.DTOs
public class SearchShopsDTO
{
    public int Userid {  get; set; }
	public string ShopTitle { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }

}
