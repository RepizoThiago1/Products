using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository.@base;

namespace Products.Domain.Interfaces.Repository
{
    public interface IPurchaseOrderRepository : IGenericRepository<PurchaseOrder>
    {
        public IQueryable<Product> QueryOrder(string query);

    }
}
