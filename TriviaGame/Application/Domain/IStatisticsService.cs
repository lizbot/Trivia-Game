
using System;
using System.Collections.Generic;
using Application.Model;


namespace Application.Domain
{
    public interface IStatisticsService
    {
        Double GetOverallStatistics();

        Double GetGameStatistics();

        Int32 GetLongestStreak();

    }
}