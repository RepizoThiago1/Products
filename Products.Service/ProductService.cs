using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

namespace Products.Service
{
    public class ProductService : IProductService
    {
        public Category AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
