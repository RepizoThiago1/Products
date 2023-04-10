using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository.@base;

namespace Products.Domain.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public void SaveChanges();
    }
}
