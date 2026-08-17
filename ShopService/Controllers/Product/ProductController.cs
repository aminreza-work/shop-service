using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var result = _repo.GetProducts();

            if (result.IsSuccess)
            {
                var mappedData = _mapper.Map<IEnumerable<SearchProductsDTO>>(result.Data);
                return Ok(mappedData);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("{id}")]
        public ActionResult<ReadProductDTO> Read(Guid productId)
        {

            var result = _repo.GetProductById(productId);
            if (result.IsSuccess)
            {
                var mappedData = _mapper.Map<ReadProductDTO>(result.Data);
                return Ok(mappedData);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDTO dto)
        {
            var result = _repo.CreateProduct(
                dto.ShopId,
                dto.Title,
                dto.Price,
                dto.Qty,
                dto.IsPublished
            );

            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.Message);


        }
    }
}
