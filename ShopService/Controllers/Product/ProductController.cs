using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<CreateProductDTO> _validator;
        public ProductController(
            IProduct repository,
            IMapper mapper,
            IValidator<CreateProductDTO> validator)
        {
            _repo = repository;
            _mapper = mapper;
            _validator = validator;
        }


        [HttpGet]
        // [GET] api/product?page=1
        public ActionResult<IEnumerable<SearchProductsDTO>> Search(int page)
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
        // [GET] api/product/a3e930f6-a0dd-4d93-b1a6-95ef8cca7de5   
        public ActionResult<ReadProductDTO> Read(Guid productId)
        {
            // Http & Routing - Restful API
            var result = _repo.GetProductById(productId);
            if (result.IsSuccess)
            {
                var mappedData = _mapper.Map<ReadProductDTO>(result.Data);
                return Ok(mappedData);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        // [POST] api/product
        public IActionResult Create(CreateProductDTO dto)
        {

            var validateRes = _validator.Validate(dto);

            if (!validateRes.IsValid)
            {
                var errors = validateRes.Errors.Select(e => new
                {
                    Property = e.PropertyName,
                    Message = e.ErrorMessage
                });
                return BadRequest(errors);
            }

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

        [HttpPut("{id}")]
        //[PUT] api/product/a3e930f6-a0dd-4d93-b1a6-95ef8cca7de5
        public IActionResult UpdateProduct(Guid id, [FromBody] UpdateProductDTO input)
        {
            var result = _repo.UpdateProduct(
                id,
                input.Qty,
                input.Price
             );
            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.Message);
        }
    }
}


