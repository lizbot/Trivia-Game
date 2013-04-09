using System;

namespace Infrastructure.Model
{
    public class Questions
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 QuestionId { get; set; }

        public String QuestionName { get; set; }

        public Int32 TimesViewed { get; set; }

        public Int32 TimesCorrect { get; set; }

        public Int32 CategoryId { get; set; }
    }
}
