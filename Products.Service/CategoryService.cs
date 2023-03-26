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

        public Category AddCategory(Category category)
        {
            var dbCheck = _repository.Find(c => c.Reference == category.Reference);

            if (dbCheck != null)
            {
                throw new Exception("You cannot add a category with same reference name");
            }

            _repository.Add(category);
            return category;
        }

        public Category GetCategory(Guid id)
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
