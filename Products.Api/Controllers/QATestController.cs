using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.ProductQATests;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;

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
                var QATest = _service.ApproveProduct(request);

                BaseResponse<QATest> response = new()
                {
                    Message = "Success !",
                    Content = QATest,
                };

                return Ok(response);
            }
            catch (QATestNotApprovedException error)
            {
                return Conflict(error.Message);
            }
            catch (ProductNotFoundException error)
            {
                return NotFound(error.Message);
            }
            catch (ReferenceNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }
    }
}
