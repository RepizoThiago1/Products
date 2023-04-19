using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository.@base;

namespace Products.Domain.Interfaces.Repository
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
    {
        public void SaveChanges();
    }
}
