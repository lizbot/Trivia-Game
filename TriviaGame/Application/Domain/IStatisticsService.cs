using System;

namespace Application.Domain
{
    public interface IStatisticsService
    {
        Double GetOverallStatistics();

        Double GetGameStatistics();

        Int32 GetLongestStreak();

        Int32 GetTotalAnsweredCorrectly();

        Int32 GetTotalQuestionsAnswered();

        void AnalyzeEndOfGameData();
    }
}