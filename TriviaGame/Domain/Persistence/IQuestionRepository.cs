namespace Domain.Persistence
{
    using System.Collections.Generic;

    using Domain.Model;

    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions();
    }
}