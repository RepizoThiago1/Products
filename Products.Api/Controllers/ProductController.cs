using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            var product = _service.GetProduct(productId);

            return Ok(product);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _service.GetAllProducts();

            return Ok(products);
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(CreateProductDTO product)
        {
            _service.AddProduct(product);

            return Ok(product);
        }
    }
}
