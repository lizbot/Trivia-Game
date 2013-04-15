using System;
using System.Collections.Generic;
using Application.Model;

namespace Application.Domain
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions(Int32? categoryId = 0);

        Question GetExistingQuestion(Int32 questionId);
        
        void StoreAnsweredQuestion(Int32 questionId, Int32 answerId);

        void IncrementTimesViewedAndOrTimesCorrect(Question question);
    }
}