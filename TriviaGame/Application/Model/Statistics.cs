using System;

namespace Application.Model
{
    public class Statistics
    {

        /// <summary>
        ///Longest streak of number of questions answered correctly.
        ///Longest streak for wrong answers.
        ///Total number of questions correct
        ///Total number of questions attempted
        ///Percentage of correct answers.
        /// </summary>
        /// 
        //public Int32 StatisticsId { get; set; } 

        public Int32 StreakofCorrectAnswers { get; set; }

        public Int32 TotalCorrectAnswers { get; set; }
        
        public Int32 TotalQuestionsAttempted { get; set; }

        public Int32 GameQuestionsAttempted { get; set; }
        
        public Double PercentageCorrect { get; set; }
    }
}