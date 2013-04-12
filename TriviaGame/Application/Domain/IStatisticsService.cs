
using System;
using System.Collections.Generic;
using Application.Model;


namespace Application.Domain
{
    public interface IStatisticsService
    {
        Int32 GetOverallStatistics();

        Int32 GetGameStatistics();

    }
}