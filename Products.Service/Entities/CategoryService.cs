using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.Workflow
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
            var categoryName = _repository.Find(x => x.CategoryName == categoryDTO.CategoryName).FirstOrDefault();

            if (categoryName != null)
            {
                throw new Exception("Cannot use the same name in category");
            }

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
