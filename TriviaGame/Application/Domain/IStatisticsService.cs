using System;

namespace Application.Domain
{
    public interface IStatisticsService
    {
        Double GetPercentageOfOverallStatistics();

        Double GetGameStatistics();

        Int32 GetLongestStreak();

        Int32 GetOverallAnsweredCorrectly();

        Int32 GetOverallQuestionsAnswered();

        Int32 GetCurrentGameCorrectAnswers();

        Int32 GetCurrentGameQuestionsAttempted();

        Int32 GetCurrentGameLongestStreak();
        
        void AnalyzeEndOfGameData();
    }
}