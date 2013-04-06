using System;
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

<<<<<<< HEAD

        public Category GetCategoryById(Int32 categoryId)
=======
        /*
        public Category GetCategoryByID(Int32 CategoryID)
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        {
            throw new NotImplementedException();
        }
        */

        public IEnumerable<Category> GetCategories() 
        {
            var category = _CategoryRepository.GetCategories();

            return category;           
        }
    }
}
