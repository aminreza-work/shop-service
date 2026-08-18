using AutoMapper;
using ShopService.Controllers.Shop.DTOs;
using ShopService.Entities;

namespace ShopService.Controllers.Shop.DTOs
{
    public class ShopMapper : Profile
    {

        public ShopMapper() 
        { 
            
            CreateMap<Entities.Shop, SearchShopsDTO>()
                .Include(x => x.ShopTitle)
                .Include(x => x.PhoneNumber)
                .Include(x => x.Userid)
                if (User id = null)
                    return "Unknown Error";

        }
    }




}