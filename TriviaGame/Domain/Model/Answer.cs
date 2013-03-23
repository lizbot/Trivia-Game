using System;

namespace Domain.Model
{
    public class Answer
    {
        public Int32 AnswerId { get; set; }

        public Int32 QuestionId { get; set; }

        public String Name { get; set; }

        public Boolean IsCorrect { get; set; }
    }
}