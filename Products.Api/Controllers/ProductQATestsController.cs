using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.ProductQATests;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQATestsController : Controller
    {
        private readonly IProductQATestsService _service;

        public ProductQATestsController(IProductQATestsService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ProductQATests> AproveProduct(ProductQATestsDTO productQATestsDTO)
        {
            var test = _service.AproveProduct(productQATestsDTO);
            return Ok(test);
        }
    }
}
