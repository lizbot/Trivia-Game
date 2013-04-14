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
        public Double GetOverallStatistics()
        {
            var overallStatistics = 0;

            var totalAnsweredCorrectly = _StatisticsRepository.GetOverallCorrectAnswers();
            var totalQuestionsAnswered = _StatisticsRepository.GetOverallQuestionsAttempted();

            overallStatistics = (totalAnsweredCorrectly / totalQuestionsAnswered) * 100;

            return overallStatistics;
        }

        public Int32 GetTotalAnsweredCorrectly()
        {
            return _StatisticsRepository.GetOverallCorrectAnswers();
        }

        public Int32 GetTotalQuestionsAnswered()
        {
            return _StatisticsRepository.GetOverallQuestionsAttempted();
        }

        public Double GetGameStatistics()
        {
            var thisGameStatistics = 0;

            var answeredCorrectlyThisGame = _StatisticsRepository.GetGameCorrectAnswers();
            var questionsAttemptedThisGame = _StatisticsRepository.GetGameQuestionsAttempted();

            thisGameStatistics = (answeredCorrectlyThisGame / questionsAttemptedThisGame) * 100;

            return thisGameStatistics;
        }

        public Int32 GetLongestStreak()
        {
            Int32 longestStreak = 0;

            longestStreak = _StatisticsRepository.GetGameLongestStreak();

            return longestStreak;
        }

    }
}
