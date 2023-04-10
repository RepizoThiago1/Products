using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Customer;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

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
        public ActionResult<Customer> GetCustomer(int customerId)
        {
            var customer = _service.GetCostumer(customerId);

            return Ok(customer);
        }

        [HttpGet("GetCustomers")]
        public ActionResult<IEnumerable<Customer>> GetCustomers ()
        {
            var customers =  _service.GetAllCostumers();

            return Ok(customers);
        }

        [HttpPost("AddCustomers")]
        public ActionResult<Customer> AddCustomer (CustomerDTO customerDTO) 
        {
            _service.AddCustomer(customerDTO);

            return Ok(customerDTO);
        }
    }
}
