using System;
using System.Collections.Generic;
using Application.Model;

namespace Application.Domain
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions(Int32? categoryId = 0);

        void StoreAnsweredQuestion(Int32 questionId, Int32 answerId);

        Question GetExistingQuestion(Int32 questionId);
    }
}