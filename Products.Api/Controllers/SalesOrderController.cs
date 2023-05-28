using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;

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
        public ActionResult<BaseResponse<SalesOrder>> GetOrder(SalesOrderDTO request)
        {
            try
            {
                var saleOrder = _service.CreateSaleOrder(request);

                if (request == null)
                {
                    return BadRequest("Please insert the right json format");
                }

                BaseResponse<SalesOrder> response = new()
                {
                    Message = "Order created !",
                    Content = saleOrder
                };

                return Ok(response);
            }
            catch (CustomerNotFoundException error)
            {
                return NotFound(error.Message);
            }
            catch (ProductNotFoundException error)
            {
                return NotFound(error.Message);
            }

        }
    }
}
