using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Product;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;
using System.Net;

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
            var content = _service.GetProduct(productId);

            var response = BaseResponse<Product>.ToResponse(HttpStatusCode.Found, "Product found!", content);

            return response;
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var contentList = _service.GetAllProducts();

            var response = BaseResponse<IEnumerable<Product>>.ToResponse(HttpStatusCode.Found, "Products found!", contentList);

            return response;
        }

        [HttpPost]
        public ActionResult<BaseResponse<ProductDTO>> AddProduct(ProductDTO request)
        {
            try
            {
                var content = _service.AddProduct(request);

                var response = BaseResponse<ProductDTO>.ToResponse(HttpStatusCode.Created, "Product created!", request);

                return Ok(response);
            }
            catch (InvalidPriceException error)
            {
                var response = BaseResponse<ProductDTO>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response;
            }
            catch (ReferenceNotFoundException error)
            {
                var response = BaseResponse<ProductDTO>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response;
            }
            catch (CategoryNotFoundException error)
            {
                var response = BaseResponse<ProductDTO>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response;
            }
        }
    }
}
