using System;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;
    using Model;

    public class QuestionService
    {
        private IQuestionRepository _QuestionRepository;

        public IEnumerable<Question> GetQuestions()
        {
            //This is an example on how to program against the interface. :-)
            // _QuestionRepository.GetQuestions(20);

            throw new NotImplementedException();
        }
    }
}