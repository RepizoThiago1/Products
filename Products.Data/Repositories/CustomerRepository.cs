using Products.Data.Context;
using Products.Data.Repositories.@base;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;

namespace Products.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }
    }
}
