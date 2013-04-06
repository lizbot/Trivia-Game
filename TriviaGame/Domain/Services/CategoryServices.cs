using Application.Domain;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository) 
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
