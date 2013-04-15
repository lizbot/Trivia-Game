using System;

namespace Application.Model
{

    /// <summary>
    ///Longest streak of number of questions answered correctly.
    ///Longest streak for wrong answers.
    ///Total number of questions correct
    ///Total number of questions attempted
    ///Percentage of correct answers.
    /// 
    /// StatisticsId = 1, Overall game statistics.
    /// StatisticsId = 2, End of Game statistics.
    /// </summary>
    public class EndOfGameStatistics
    {
        public Int32 StatisticsId { get; set; }

        public Int32 StreakofCorrectAnswers { get; set; }

        public Int32 TotalCorrectAnswers { get; set; }

        public Int32 TotalWrongAnswers { get; set; }
    }
}