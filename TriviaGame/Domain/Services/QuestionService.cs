using System;
using Application.Domain;
using Application.Model;
using AutoMapper;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _QuestionRepository;

        // Change this when we implement default settings to program against.
        private Int32 _DefaultNumber = 20;

        // this is a type of constructor injection for dependency injection.
        public QuestionService (IQuestionRepository questionRepository)
        {
            _QuestionRepository = questionRepository;
        }

        public IEnumerable<Question> GetQuestions()
        {
            // this gets the IEnumerable<Question> of all the questions that you want from the database.
            var questions = _QuestionRepository.GetQuestions(_DefaultNumber);

            return questions;
        }

        //Gets the questions as a parameter and gets them back to the repository
        //Statistics service to know about the user. Percent correct (calculate this somewhere else)
    }
}