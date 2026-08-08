using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.Controllers.Product.DTOs;
using ShopService.Entities;
using ShopService.Repositories;

namespace ShopService.Controllers.Product
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;
        private readonly IMapper _mapper;
        public ProductController(
            IProduct repository,
            IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<SearchProductsDTO>> Search()
        {
            var products = _repo.GetProducts();

            var mappedProducts = _mapper.Map<IEnumerable<SearchProductsDTO>>(products);

            return Ok(mappedProducts);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductsDTO dto)
        {
            _repo.CreateProduct(
                dto.Title,
                dto.Price,
                dto.Qty,
                dto.IsPublished
            );

            return Ok();
        }
    }
}
