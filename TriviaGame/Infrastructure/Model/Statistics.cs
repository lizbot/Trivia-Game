using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    class Statistics
    {
        //[SQLite.PrimaryKey, SQLite.AutoIncrement]
        //public Int32 StatisticsId { get; set; } 

        public Int32 StreakofCorrectAnswers { get; set; }

        public Int32 TotalCorrectAnswers { get; set; }

        public Int32 TotalQuestionsAttempted { get; set; }

        public Int32 GameQuestionsAttempted { get; set; }

        public Double PercentageCorrect { get; set; }
    }
}
