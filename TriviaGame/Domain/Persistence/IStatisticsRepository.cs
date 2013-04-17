using System;


namespace Domain.Persistence
{
    public interface IStatisticsRepository
    {
        Int32 GetOverallCorrectAnswers();

        Int32 GetOverallQuestionsAttempted();

        Int32 GetCurrentGameCorrectAnswers();

        Int32 GetCurrentGameQuestionsAttempted();
        
        Int32 GetCurrentGameLongestStreak();

        Int32 GetOverallLongestStreak();

        void AnalyzeEndOfGameData();
    }
}
