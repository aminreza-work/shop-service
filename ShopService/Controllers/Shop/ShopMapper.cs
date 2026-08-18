using AutoMapper;
using ShopService.Entities;
using ShopService.Controllers.Shop.DTOs;

namespace ShopService.Controllers.Shop.DTOs
{
    public class ShopMapper : Profile
    {
        public ShopMapper()
        {
            CreateMap<Entities.Shop, SearchShopsDTO>()
                .ForMember(d => d.ShopTitle, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                .ForMember(d => d.Userid, opt => opt.MapFrom(s => s.Id));
        }
    }
}