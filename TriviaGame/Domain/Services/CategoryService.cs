using System;
using Application.Domain;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        private readonly IQuestionRepository _QuestionRepository;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IQuestionRepository questionRepository)
        {
            _CategoryRepository = categoryRepository;
            _QuestionRepository = questionRepository;
        }

        public IEnumerable<Category> GetCategories() 
        {
            var category = _CategoryRepository.GetCategories();

            return category;           
        }

        public IEnumerable<Question> GetQuestionsForCategory(Int32 numberOfQuestions, Int32 categoryId)
        {
            var questions = _QuestionRepository.GetQuestions(numberOfQuestions, categoryId);

            return questions;
        }

        public Boolean DoCustomQuestionsExist()
        {
            var exists = _CategoryRepository.DoCustomQuestionsExist();

            return exists;
        }
    }
}
