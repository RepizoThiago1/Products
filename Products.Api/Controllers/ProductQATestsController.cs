using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.ProductQATests;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
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
        public ActionResult<ProductQATests> ApproveProduct(ProductQATestsDTO productQATestsDTO)
        {
            try
            {
                var test = _service.ApproveProduct(productQATestsDTO);
                return Ok(test);
            }
            catch (QATestNotApprovedException error)
            {
                return Conflict(error.Message);
            }
            catch (ProductNotFoundException error)
            {
                return NotFound(error.Message);
            }
            catch (ReferenceNotFoundException error) 
            {
                return NotFound(error.Message);
            }
        }
    }
}
