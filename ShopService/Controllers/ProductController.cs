using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.Entities;

namespace ShopService.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductController(AppDbContext context)
        {
            _db = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Search()
        {
            var products = _db.Products.ToList();

            return Ok(products);
        }
    }
}
