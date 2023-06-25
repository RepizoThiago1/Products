using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Reference;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Responses.@base;
using Products.Service.Entities;
using System.Net;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReferencesController : ControllerBase
    {
        private readonly IProductReferencesService _service;

        public ProductReferencesController(IProductReferencesService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<BaseResponse<ProductReferences>> AddProductReferences(ProductReferencesDTO request)
        {
            try
            {
                var content = _service.AddReference(request);

                var response = BaseResponse<ProductReferences>.ToResponse(HttpStatusCode.Created, "Reference created!", content);

                return response;
            }
            catch (ReferenceExistisException error)
            {
                var response = BaseResponse<ProductReferences>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response;
            }

        }
    }
}
