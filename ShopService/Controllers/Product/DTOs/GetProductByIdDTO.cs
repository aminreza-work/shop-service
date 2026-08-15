using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopService.Entities;

namespace ShopService.Controllers.Product.DTOs
{
    public class GetProductByIdDTO : SearchProductsDTO
    {
        public Nullable <Guid> Id { get; set; } 
        public int Qty { get; set; }
        public bool IsPublished { get; set; }
    }
}
