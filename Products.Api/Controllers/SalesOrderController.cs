using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _service;

        public SalesOrderController(ISalesOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<SalesOrder> GetOrder(SalesOrderDTO request)
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
