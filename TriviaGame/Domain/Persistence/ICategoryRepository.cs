using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Persistence
{
   public interface ICategoryRepository
    {
       IEnumerable<Category> GetCategories();
    }
}
