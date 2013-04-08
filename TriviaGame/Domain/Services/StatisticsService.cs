using System;
using Application.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Persistence;


namespace Domain.Services
{
    public class StatisticsService
    {
        private readonly IStatisticsRepository _StaisticsRepository;

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _StaisticsRepository = statisticsRepository;
        }

        //The easiest way to get and process user statistics is to use integers 
        public Int32 GetOverallStatistics()
        {
            Int32 overallStatistics = 0;

            Int32 totalAnsweredCorrectly = _StaisticsRepository.GetOverallCorrectAnswers();
            Int32 totalQuestionsAnswered = _StaisticsRepository.GetOverallQuestionsAttempted();

            overallStatistics = (totalQuestionsAnswered / totalAnsweredCorrectly);

            return overallStatistics;

        }

        public Int32 GetGameStatistics()
        {
            Int32 gameStatistics = 0;

            Int32 answeredCorrectly = _StaisticsRepository.GetGameCorrectAnswers();
            Int32 questionsAnswered = _StaisticsRepository.GetGameQuestionsAttempted();

            gameStatistics = (questionsAnswered / answeredCorrectly);

            return gameStatistics;
        }

    }
}
