using System;
using System.Collections.Generic;
using Application.Model;
namespace Application.Domain
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<Question> GetQuestionsForCategory(Int32 numberOfQuestions, Int32 categoryId);

        Boolean DoCustomQuestionsExist();
    }
}
