using Products.Domain.DTO.Category;
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
            var categoryReference = _repository.Find(x => x.Reference == categoryDTO.Reference).FirstOrDefault();

            if (categoryName != null) 
                throw new Exception("Category name alread in use");

            if (categoryReference != null)
                throw new Exception("Reference already in use");

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
