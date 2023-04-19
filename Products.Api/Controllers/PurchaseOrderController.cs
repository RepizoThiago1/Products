using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.PurchaseOrder;
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
        public ActionResult<PurchaseOrder> GetOrder(PurchaseOrderRequestDTO request)
        {
            try
            {
                var response = _service.CreatePurchaseOrder(request);

                if (response == null)
                {
                    return BadRequest("Please insert the right json format");
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
