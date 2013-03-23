using System.Collections.Generic;
using Application.DTOs;

namespace Application.Domain
{
    public interface IQuestionService
    {
        IEnumerable<QuestionDto> GetQuestions();
    }
}