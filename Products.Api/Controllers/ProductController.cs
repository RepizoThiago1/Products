using Microsoft.AspNetCore.Mvc;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly  IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(Guid productId)
        {
            var product = _repository.GetById(productId);

            return Ok(product);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _repository.GetAll();

            return Ok(products);
        }

        [HttpPost]
        public ActionResult<Product> AddProduct (Product product)
        {
            _repository.Add(product);

            return Ok(product);
        }
    }
}
