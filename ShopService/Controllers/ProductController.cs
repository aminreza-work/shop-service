using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.Entities;
using ShopService.Repositories;

namespace ShopService.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;
        public ProductController(IProduct repository)
        {
            _repo = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Search()
        {
            var products = _repo.GetProducts();
            //Map (Automapper : Product => SearchProductDTO)
            return Ok(products);
        }
    }
}
