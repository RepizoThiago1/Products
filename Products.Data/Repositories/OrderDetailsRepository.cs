using Products.Data.Context;
using Products.Data.Repositories.@base;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;

namespace Products.Data.Repositories
{
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(DataContext context) : base(context)
        {
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
