using System.Collections.Generic;
using Application.Model;

namespace Domain.Persistence
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswers();
    }
}
