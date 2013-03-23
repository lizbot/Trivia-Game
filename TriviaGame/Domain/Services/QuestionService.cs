using System;
using Application.DTOs;
using Application.Domain;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;
    using Model;

    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _QuestionRepository;

        public IEnumerable<QuestionDto> GetQuestions()
        {
            //This is an example on how to program against the interface. :-)
            // _QuestionRepository.GetQuestions(20);

            throw new NotImplementedException();
        }
    }
}