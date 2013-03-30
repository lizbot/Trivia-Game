using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Domain;
using Domain.Persistence;
using Domain.Model;
using AutoMapper;

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


        public Category getCategoryByID(Int32 CategoryID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories() 
        {
            Mapper.CreateMap<Category, CategoryDto>();

            Category category = _CategoryRepository.GetCategories();

            var categoryDtos = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDto>>(category);

            return categoryDtos;
            
            throw new NotImplementedException();
        }
    }
}
