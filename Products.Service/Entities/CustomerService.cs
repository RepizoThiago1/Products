using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.Workflow
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer AddCustomer(CustomerDTO customerDTO)
        {
            Customer customer = new()
            {
                Name = customerDTO.Name,
                Address = customerDTO.Address,
                TelephoneNumber = customerDTO.TelephoneNumber,
                Email = customerDTO.Email,
                ZipCode = customerDTO.ZipCode,
                IsActive = customerDTO.IsActive
            };

            _repository.Add(customer);

            return customer;
        }

        public IEnumerable<Customer> GetAllCostumers()
        {
            return _repository.GetAll();
        }

        public Customer GetCostumer(int id)
        {
            return _repository.GetById(id);
        }
    }
}
