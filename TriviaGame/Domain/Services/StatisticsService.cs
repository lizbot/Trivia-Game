using System;
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
            var overallStatistics = 0;

            var totalAnsweredCorrectly = _StaisticsRepository.GetOverallCorrectAnswers();
            var totalQuestionsAnswered = _StaisticsRepository.GetOverallQuestionsAttempted();

            overallStatistics = (totalQuestionsAnswered / totalAnsweredCorrectly);

            return overallStatistics;

        }

        public Int32 GetGameStatistics()
        {
            var gameStatistics = 0;

            var answeredCorrectly = _StaisticsRepository.GetGameCorrectAnswers();
            var questionsAnswered = _StaisticsRepository.GetGameQuestionsAttempted();

            gameStatistics = (questionsAnswered / answeredCorrectly);

            return gameStatistics;
        }

    }
}
