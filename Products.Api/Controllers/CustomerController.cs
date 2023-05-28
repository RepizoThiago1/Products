using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Customer;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;

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
            var customer = _service.GetCostumer(customerId);

            BaseResponse<Customer> response = new()
            {
                Message = "Success !",
                Content = customer,
            };

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = _service.GetAllCostumers();

            BaseResponse<Customer> response = new()
            {
                Message = "Success !",
                ContentList = customers,
            };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<BaseResponse<Customer>> AddCustomer(CustomerDTO request)
        {
            try
            {
                var customer = _service.AddCustomer(request);

                BaseResponse<Customer> response = new()
                {
                    Message = "Success !",
                    Content = customer,
                };

                return Ok(customer);
            }
            catch (CustomerCodeExistsException error)
            {
                return BadRequest(error.Message);
            }
            catch (CustomerNameExistsException error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
