using System;

namespace Application.Model
{
    public class OverallStatistics
    {
        public Int32 StatisticsId { get; set; }

        public Int32 TotalQuestionsAttempted { get; set; }

        public Int32 TotalGameQuestionsAttempted { get; set; }

        public Double OverallPercentageCorrect { get; set; }
    }
}