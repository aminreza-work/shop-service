using AutoMapper;
using ShopService.Controllers.Product.DTOs;
using ShopService.Entities;

namespace ShopService.Controllers.Product
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Entities.Product, SearchProductsDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("F")))
                .ForMember(d => d.ShopTitle, opt => opt.MapFrom((s, d) =>
                {
                    if (s.Shop == null)
                        return "نامشخص";
                    return s.Shop.Title;
                }));
        }
    }
}
