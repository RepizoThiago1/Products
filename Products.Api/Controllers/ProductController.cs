using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Product;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;

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
        public ActionResult<BaseResponse<Product>> GetProduct(int productId)
        {
            var product = _service.GetProduct(productId);

            BaseResponse<Product> response = new()
            {
                Message = "Success !",
                Content = product
            };

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var products = _service.GetAllProducts();

            BaseResponse<Product> response = new()
            {
                Message = "Success !",
                ContentList = products,
            };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<BaseResponse<ProductDTO>> AddProduct(ProductDTO request)
        {
            try
            {
                var product = _service.AddProduct(request);

                _service.GetProduct(product.Id);

                BaseResponse<Product> response = new()
                {
                    Message = "Success !",
                    Content = product
                };

                return Ok(response);
            }
            catch (InvalidPriceException error)
            {
                return BadRequest(error.Message);
            }
            catch (ReferenceNotFoundException error)
            {
                return NotFound(error.Message);
            }
            catch (CategoryNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }
    }
}
