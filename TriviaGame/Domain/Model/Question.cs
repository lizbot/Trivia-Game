using System;
using System.Collections.Generic;
using Domain.Extensions;

namespace Domain.Model
{
    public class Question
    {
        //[SQLite.AutoIncrement, SQLite.PrimaryKey] //TODO(LM): Figure out a way to attribute this to properties in the infrastructure.

        [PrimaryKey, AutoIncrement]
        public Int32 QuestionId { get; set; }

        public String QuestionName { get; set; }

        public Answer CorrectAnswer { get; set; }

        public IEnumerable<Answer> WrongAnswers { get; set; }

        public Int32 TimesViewed { get; set; }

        public Int32 TimesCorrect { get; set; }

        public Int32 CategoryId { get; set; }
    }
}
