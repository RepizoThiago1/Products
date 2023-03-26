using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Category AddProduct(Product product);
        Category GetCategory(Guid id);
        IEnumerable<Category> GetAllCategories();
    }
}
