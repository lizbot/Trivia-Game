using System;
using Domain.Persistence;
using Application.Domain;


namespace Domain.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _StatisticsRepository;

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _StatisticsRepository = statisticsRepository;
        }

        //The easiest way to get and process user statistics is to use integers 
        public Int32 GetOverallStatistics()
        {
            var overallStatistics = 0;

            var totalAnsweredCorrectly = _StatisticsRepository.GetOverallCorrectAnswers();
            var totalQuestionsAnswered = _StatisticsRepository.GetOverallQuestionsAttempted();

            overallStatistics = (totalQuestionsAnswered / totalAnsweredCorrectly);

            return overallStatistics * 100;
        }

        public Int32 GetTotalAnsweredCorrectly()
        {
            return _StatisticsRepository.GetOverallCorrectAnswers();
        }

        public Int32 GetTotalQuestionsAnswered()
        {
            return _StatisticsRepository.GetOverallQuestionsAttempted();
        }

        public Int32 GetGameStatistics()
        {
            var gameStatistics = 0;

            var answeredCorrectly = _StatisticsRepository.GetGameCorrectAnswers();
            var questionsAnswered = _StatisticsRepository.GetGameQuestionsAttempted();

            gameStatistics = (questionsAnswered / answeredCorrectly);

            return gameStatistics;
        }

    }
}
