using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.PurchaseOrder;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;
using System.Net;

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
                var content = _service.CreateSaleOrder(request);

                var response = BaseResponse<SalesOrder>.ToResponse(HttpStatusCode.Created, "Order created!", content);

                return response;
            }
            catch (CustomerNotFoundException error)
            {
                var response = BaseResponse<SalesOrder>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }
            catch (ProductNotFoundException error)
            {
                var response = BaseResponse<SalesOrder>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }

        }
    }
}
