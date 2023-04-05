using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category AddCategory(CategoryDTO categoryDTO)
        {

            Category category = new()
            {
                CategoryName = categoryDTO.CategoryName,
                Reference = categoryDTO.Reference
            };

            _repository.Add(category);
            return category;
        }

        public Category GetCategory(int id)
        {
            _repository.GetById(id);

            return _repository.GetById(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var list = _repository.GetAll();

            return list;
        }
    }
}
