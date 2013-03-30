using System.Collections.Generic;
using Application.DTOs;
using System;

namespace Application.Domain
{
    public interface IQuestionService
    {
        IEnumerable<QuestionDto> GetQuestions();
    }
}