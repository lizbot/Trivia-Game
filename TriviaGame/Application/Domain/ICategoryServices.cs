using System.Collections.Generic;
using Application.Model;
namespace Application.Domain
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetCategories();
    }
}
