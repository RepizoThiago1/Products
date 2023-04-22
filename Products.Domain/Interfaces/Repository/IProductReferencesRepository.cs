using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository.@base;

namespace Products.Domain.Interfaces.Repository
{
    public interface IProductReferencesRepository : IGenericRepository<ProductReferences>
    {
        public void SaveChanges();
    }
}
