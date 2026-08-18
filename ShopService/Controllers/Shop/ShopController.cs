using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShopService.Controllers.Shop.DTOs;
using ShopService.Entities;
using ShopService.Repositories;

namespace ShopService.Controllers.Shop
{
    [Route("api/Shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShop _repo;
        private readonly IMapper _mapper;
        public ShopController(
            IShop repository,
            IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
    }
}
