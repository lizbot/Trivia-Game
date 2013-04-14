using System;
namespace Application.Domain
{
    public interface IStatisticsService
    {
        Int32 GetOverallStatistics();

        Int32 GetTotalAnsweredCorrectly();

        Int32 GetTotalQuestionsAnswered();

        Int32 GetGameStatistics();
    }
}