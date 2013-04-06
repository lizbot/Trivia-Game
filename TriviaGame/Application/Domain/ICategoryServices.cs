using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryDto> GetCategories();
    }
}
