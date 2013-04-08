using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Persistence
{
    public interface IStatisticsRepository
    {
        public Int32 GetOverallCorrectAnswers();

        public Int32 GetOverallQuestionsAttempted();

        public Int32 GetGameCorrectAnswers();

        public Int32 GetGameQuestionsAttempted();

    }
}
