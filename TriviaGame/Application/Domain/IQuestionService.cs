using System.Collections.Generic;
using Application.Model;

namespace Application.Domain
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions();

        void StoreAnsweredQuestion(AnsweredQuestion question);
    }
}