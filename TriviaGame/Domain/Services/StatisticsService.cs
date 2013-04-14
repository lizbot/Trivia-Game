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
        public Double GetOverallStatistics()
        {
            var overallStatistics = 0;

            var totalAnsweredCorrectly = _StaisticsRepository.GetOverallCorrectAnswers();
            var totalQuestionsAnswered = _StaisticsRepository.GetOverallQuestionsAttempted();

            overallStatistics = (totalAnsweredCorrectly / totalQuestionsAnswered) * 100;

            return overallStatistics;

        }

        public Double GetGameStatistics()
        {
            var thisGameStatistics = 0;

            var answeredCorrectlyThisGame = _StaisticsRepository.GetGameCorrectAnswers();
            var questionsAttemptedThisGame = _StaisticsRepository.GetGameQuestionsAttempted();

            thisGameStatistics = (answeredCorrectlyThisGame / questionsAttemptedThisGame) * 100;

            return thisGameStatistics;
        }

        public Int32 GetLongestStreak()
        {
            Int32 longestStreak = 0;

            longestStreak = _StaisticsRepository.GetGameLongestStreak();

            return longestStreak;
        }

    }
}
