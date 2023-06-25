using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.ProductQATests;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;
using System.Net;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QATestController : Controller
    {
        private readonly IQATestService _service;

        public QATestController(IQATestService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<BaseResponse<QATest>> ApproveProduct(QATestDTO request)
        {
            try
            {
                var content = _service.ApproveProduct(request);

                var response = BaseResponse<QATest>.ToResponse(HttpStatusCode.Created, "Test done!", content);

                return response;
            }
            catch (QATestNotApprovedException error)
            {
                var response = BaseResponse<QATest>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response;
            }
            catch (ProductNotFoundException error)
            {
                var response = BaseResponse<QATest>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }
            catch (ReferenceNotFoundException error)
            {
                var response = BaseResponse<QATest>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }
        }
    }
}
