using Products.Domain.DTO;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Customer AddCustomer(CreateCustomerDTO product);
        Customer GetCostumer(int id);
        IEnumerable<Customer> GetAllCostumers();
    }
}
