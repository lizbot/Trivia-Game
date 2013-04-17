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
        public Double GetPercentageOfOverallStatistics()
        {
            Double totalAnsweredCorrectly = _StatisticsRepository.GetOverallCorrectAnswers();
            Double totalQuestionsAnswered = _StatisticsRepository.GetOverallQuestionsAttempted();

            var overallStatistics = (totalAnsweredCorrectly / totalQuestionsAnswered) * 100;

            return Math.Truncate(overallStatistics);
        }

        public Int32 GetTotalAnsweredCorrectly()
        {
            return _StatisticsRepository.GetOverallCorrectAnswers();
        }

        public Int32 GetTotalQuestionsAnswered()
        {
            return _StatisticsRepository.GetOverallQuestionsAttempted();
        }

        public void AnalyzeEndOfGameData()
        {
            _StatisticsRepository.AnalyzeEndOfGameData();
        }

        public Double GetGameStatistics()
        {
            var answeredCorrectlyThisGame = _StatisticsRepository.GetCurrentGameCorrectAnswers();
            var questionsAttemptedThisGame = _StatisticsRepository.GetCurrentGameQuestionsAttempted();

            var thisGameStatistics = (answeredCorrectlyThisGame / questionsAttemptedThisGame) * 100;

            return thisGameStatistics;
        }

        public Int32 GetLongestStreak()
        {
            var longestStreak = _StatisticsRepository.GetOverallLongestStreak();

            return longestStreak;
        }

    }
}
