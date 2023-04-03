using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository.@base;

namespace Products.Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
