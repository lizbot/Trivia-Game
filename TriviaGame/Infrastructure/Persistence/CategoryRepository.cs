using System.Collections.Generic;
using Application.Model;
using Domain.Persistence;

namespace Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository 
    {
        public IEnumerable<Category> GetCategories()
        {
            throw new System.NotImplementedException();
        }
    }
}