using System.Collections.Generic;
using Application.Model;

namespace Domain.Persistence
{
   public interface ICategoryRepository
    {
       IEnumerable<Category> GetCategories();
    }
}
