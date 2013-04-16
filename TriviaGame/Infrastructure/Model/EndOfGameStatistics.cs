using System;

namespace Infrastructure.Model
{
    public class EndOfGameStatistics
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 StatisticsId { get; set; } 

        public Int32 LongestStreak { get; set; }

        public Int32 TotalAnsweredCorrectly { get; set; }

        public Int32 TotalAnsweredIncorrectly { get; set; }
    }
}