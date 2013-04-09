using System.Collections.Generic;
using Application.Model;
namespace Application.Domain
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
