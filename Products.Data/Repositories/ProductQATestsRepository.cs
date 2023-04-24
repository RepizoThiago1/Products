using Products.Data.Context;
using Products.Data.Repositories.@base;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;

namespace Products.Data.Repositories
{
    public class ProductQATestsRepository : GenericRepository<ProductQATests>, IProductQATestsRepository
    {
        public ProductQATestsRepository(DataContext context) : base(context)
        {
        }
    }
}
