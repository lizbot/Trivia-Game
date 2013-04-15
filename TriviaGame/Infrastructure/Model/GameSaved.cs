using System;

namespace Infrastructure.Model
{
    class GameSaved
    {
        [SQLite.PrimaryKey]
        public Int32 QuestionId { get; set; }

        public Int32 AnswerId { get; set; }

        public Boolean? AnsweredCorrectly { get; set; }
    }
}
