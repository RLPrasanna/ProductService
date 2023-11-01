using ProductService.Models;
using ProductService.Repositories;
using System;

namespace ProductService.Services
{
    public class CategoryService:ICategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }

        public Category getCategoryById(string id)
        {
            Category category = _categoryRepository.GetById(Guid.Parse(id));

            List<Product> products = category.products;


            return category;
        }
    }
}
