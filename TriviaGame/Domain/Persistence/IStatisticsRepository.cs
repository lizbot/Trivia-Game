using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Persistence
{
    public interface IStatisticsRepository
    {
        Int32 GetOverallCorrectAnswers();

        Int32 GetOverallQuestionsAttempted();

        Int32 GetGameCorrectAnswers();

        Int32 GetGameQuestionsAttempted();

    }
}
