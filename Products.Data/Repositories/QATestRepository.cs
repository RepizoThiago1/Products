using Products.Data.Context;
using Products.Data.Repositories.@base;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;

namespace Products.Data.Repositories
{
    public class QATestRepository : GenericRepository<QATest>, IQATestRepository
    {
        public QATestRepository(DataContext context) : base(context)
        {
        }
    }
}
