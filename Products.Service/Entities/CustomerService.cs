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
            try
            {
                var customerCodeCheck = _repository.Find(c => c.CustomerCode == customerDTO.CustomerCode).FirstOrDefault();
                var customerNameCheck = _repository.Find(c => c.Name == customerDTO.Name).FirstOrDefault();

                if (customerCodeCheck != null)
                    throw new Exception("Customer code already in use");

                if (customerNameCheck != null)
                    throw new Exception("Customer name already exists");

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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

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
