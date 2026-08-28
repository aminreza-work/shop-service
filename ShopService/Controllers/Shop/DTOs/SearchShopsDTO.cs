using ShopService.Enums;

namespace ShopService.Controllers.Shop.DTOs;
public class SearchShopsDTO
{
    public int userId {  get; set; }
	public string ShopTitle { get; set; }
    public int PhoneNumber { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }

}
