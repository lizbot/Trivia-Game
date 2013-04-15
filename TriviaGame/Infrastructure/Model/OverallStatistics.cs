using System;

namespace Infrastructure.Model
{
    public class OverallStatistics
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 StatisticsId { get; set; }

        public Int32 TotalCorrectAnswers { get; set; }

        public Int32 TotalQuestionsAttempted { get; set; }

        public Int32 LongestOverallStreak { get; set; }
    }
}