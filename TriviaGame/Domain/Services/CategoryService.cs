using Application.Domain;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) 
        {
            _CategoryRepository = categoryRepository;
        }

        //public Category GetCategoryById(Int32 categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Category> GetCategories() 
        {
            var category = _CategoryRepository.GetCategories();

            return category;           
        }
    }
}
