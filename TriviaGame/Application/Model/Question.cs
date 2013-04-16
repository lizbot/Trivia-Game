using System;
using System.Collections.Generic;
using Application.Domain;

namespace Application.Model
{
    public class Question
    {
        public Int32 QuestionId { get; set; }

        public String QuestionName { get; set; }

        public Answer CorrectAnswer { get; set; }

        public Int32 TimesViewed { get; set; }

        public Int32 TimesCorrect { get; set; }

        public Int32 CategoryId { get; set; }

        public IEnumerable<Answer> WrongAnswers { get; set; }

        public void IncreaseTimesViewedAndOrTimesCorrect(IQuestionService questionService)
        {
            questionService.IncrementTimesViewedAndOrTimesCorrect(this);
        }
    }
}
