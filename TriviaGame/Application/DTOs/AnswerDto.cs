using System;

namespace Application.DTOs
{
    public class AnswerDto
    {
        public Int32 AnswerId { get; set; }

        public Int32 QuestionId { get; set; }

        public String Name { get; set; }

        public Boolean IsCorrect { get; set; } 
    }
}