using System;

namespace Application.DTOs
{
    public class StatisticsDto
    {        
        public Int32 StatisticsId { get; set; }  

        public Int32 StreakofCorrectAnswers { get; set; }

        public Int32 TotalCorrectAnswers { get; set; }

        public Int32 TotalQuestionsAttempted { get; set; }

        public Double PercentageCorrect { get; set; }
    }
}