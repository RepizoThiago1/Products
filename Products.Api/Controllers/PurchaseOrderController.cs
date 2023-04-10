using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _service;

        public PurchaseOrderController(IPurchaseOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Queue<Product>> GetOrder (List<TestRequestDTO> request)
        {
            var response = _service.CreateProductList(request);

            if (response == null) 
            {
                return BadRequest("kkkk");
            }

            return Ok(response);
        }
    }
}
