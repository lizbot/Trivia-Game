using System;
using Application.Domain;
using Application.DTOs;
using AutoMapper;
using Domain.Model;
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

        public IEnumerable<QuestionDto> GetQuestions()
        {
            // defines how the mapping will occur.  If there are properties that need custom mapping, you do so in the parameter.
            Mapper.CreateMap<Question, QuestionDto>();

            // this gets the IEnumerable<Question> of all the questions that you want from the database.
            var questions = _QuestionRepository.GetQuestions(_DefaultNumber);

            // then we have to map them to Dtos to pass to the UI layer and return them.
            var questionDtos = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDto>>(questions);

            return questionDtos;
        }
    }
}