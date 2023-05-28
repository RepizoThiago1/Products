using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Reference;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Service.Entities;


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
        public ActionResult<ProductReferences> AddProductReferences(ProductReferencesDTO request)
        {
            try
            {
                if (request == null)
                    return BadRequest();

                var reference = _service.AddReference(request);

                return Ok(reference);
            }
            catch (ReferenceExistisException error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
