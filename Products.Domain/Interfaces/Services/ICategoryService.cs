using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Category AddCategory(Category category);
        Category GetCategory(Guid id);
        IEnumerable<Category> GetAllCategories();
    }
}
