using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Reference;
using Products.Domain.Entities;
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
        public ActionResult<ProductReferences> AddProductReferences(ProductReferencesDTO productReferencesDTO)
        {
            if (productReferencesDTO == null)
                return BadRequest();

            var reference = _service.AddReference(productReferencesDTO);

            return Ok(reference);
        }
    }
}
