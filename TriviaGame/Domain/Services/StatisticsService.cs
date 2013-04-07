using System;
using System.Collections.Generic;
using Application.Domain;
using Application.Model;

namespace Domain.Services
{
     public class StatisticsService : IStatisticsService 
     {
        //Create something similar to the questions service to pass the statistics of the user.
        //This includes percent correct. Streak of answers correct. 
        public IEnumerable<Statistics> GetStatistics()
        {
            throw new NotImplementedException();

        }
    }
}
