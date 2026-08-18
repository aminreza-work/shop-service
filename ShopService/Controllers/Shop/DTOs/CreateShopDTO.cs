using System;
using ShopService.Enums;
public class CreateShopDTO
{
    public int Userid { get; set; }
    public string ShopTitle { get; set; }
    public bool IsVerified { get; set; }
    public string Address { get; set; }
    public int PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
}
    
