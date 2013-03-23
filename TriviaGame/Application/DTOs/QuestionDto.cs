using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class QuestionDto
    {
        public Int32 QuestionId { get; set; }

        public String QuestionName { get; set; }

        public AnswerDto CorrectAnswer { get; set; }

        public IEnumerable<AnswerDto> WrongAnswers { get; set; }

        public Int32 TimesViewed { get; set; }

        public Int32 TimesCorrect { get; set; }

        public Int32 CategoryId { get; set; } 
    }
}