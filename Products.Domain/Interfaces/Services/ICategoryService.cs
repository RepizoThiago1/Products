﻿using Products.Domain.DTO;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Category AddCategory(CategoryDTO category);
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
