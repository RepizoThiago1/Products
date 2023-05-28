using Products.Domain.DTO.Customer;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.Entities
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
            var customerCodeCheck = _repository.Find(c => c.CustomerCode == customerDTO.CustomerCode).FirstOrDefault();
            var customerNameCheck = _repository.Find(c => c.Name == customerDTO.Name).FirstOrDefault();

            if (customerCodeCheck != null)
                throw new CustomerCodeExistsException("Customer code already in use");

            if (customerNameCheck != null)
                throw new CustomerNameExistsException("Customer name already exists");

            Customer customer = new()
            {
                Name = customerDTO.Name,
                CustomerCode = $"BRCC{customerDTO.CustomerCode.ToUpper()}", //CC = customer code
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
