using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Customer;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;
using System.Net;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("{customerId}")]
        public ActionResult<BaseResponse<Customer>> GetCustomer(int customerId)
        {
            var content = _service.GetCostumer(customerId);

            var response = BaseResponse<Customer>.ToResponse(HttpStatusCode.Found, "Customer found!", content);

            return response;
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Customer>>> GetCustomers()
        {
            var contentList = _service.GetAllCostumers();

            var response = BaseResponse<IEnumerable<Customer>>.ToResponse(HttpStatusCode.Found, "Customers found!", contentList);

            return response;
        }

        [HttpPost]
        public ActionResult<BaseResponse<Customer>> AddCustomer(CustomerDTO request)
        {
            try
            {
                var content = _service.AddCustomer(request);

                var response = BaseResponse<Customer>.ToResponse(HttpStatusCode.Created, "Customer created!", content);

                return response;
            }
            catch (CustomerCodeExistsException error)
            {
                var response = BaseResponse<Customer>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response;
            }
            catch (CustomerNameExistsException error)
            {
                var response = BaseResponse<Customer>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response; ;
            }

        }
    }
}
