using Products.Domain.DTO;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Category AddCategory(CreateCategoryDTO category);
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
