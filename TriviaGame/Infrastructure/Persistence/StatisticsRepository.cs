using System;
using Domain.Persistence;
using Infrastructure.Initialization;
using SQLite;
using EndOfGameStatistics = Infrastructure.Model.EndOfGameStatistics;
using OverallStatistics = Infrastructure.Model.OverallStatistics; 

namespace Infrastructure.Persistence
{
    public class StatisticsRepository : IStatisticsRepository 
    {
        public Int32 GetOverallCorrectAnswers()
        {
            // Query and get the TotalCorrectAnswers from the OverallStatistics table.
            throw new NotImplementedException();
        }

        public Int32 GetOverallQuestionsAttempted()
        {
            // Query and get the TotalQuestionsAttempted from OverallStatistics table.
            throw new NotImplementedException();
        }

        public Int32 GetOverallLongestStreak()
        {
            //Query and get the LongestOverallStreak from OverallStatistics table. 
            throw new NotImplementedException();
        }

        public Int32 GetCurrentGameCorrectAnswers()
        {
            //Query and get the TotalAnsweredCorrectly from EndOfGameStatistics table.
            throw new NotImplementedException();
        }

        public Int32 GetCurrentGameQuestionsAttempted()
        {
            // Query and get the (TotalAnsweredIncorrectly + TotalAnsweredCorrectly) from EndOfGameStatistics table.
            throw new NotImplementedException();
        }

        public Int32 GetCurrentGameLongestStreak()
        {
            // Query and get EndOfGameStatistics.LongestStreak property in database.
            throw new NotImplementedException();
        }

        public void AnalyzeEndOfGameData()
        {
            using(var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();                

                var correctlyAnsweredCol = (from AnsweredCorrectly in db.Table<Model.GameSaved>()
                                            select AnsweredCorrectly).Where(q => q.AnsweredCorrectly == true).Count();

                var incorrectlyAnswerCol = (from AnsweredCorrectly in db.Table<Model.GameSaved>()
                                            select AnsweredCorrectly).Where(q => q.AnsweredCorrectly == false).Count();

                var getrows = db.Table<Model.GameSaved>();
                var streak = 0;
                var longestStreak=0;

                foreach(var row in getrows)
                {
                    if (row.AnsweredCorrectly == true)
                    {
                        streak++;
                        if (streak > longestStreak)
                            longestStreak = streak;

                        continue;
                        
                    }
                    else streak = 0;
                }

                var totalStreak = longestStreak;

                var insertStatistics = new EndOfGameStatistics 
                {
                    LongestStreak = totalStreak,
                    TotalAnsweredCorrectly = correctlyAnsweredCol,
                    TotalAnsweredIncorrectly = incorrectlyAnswerCol,
                };  


                db.Update(insertStatistics);

                var correctAnswersFromOverall = db.Get<OverallStatistics>(correct => correct.StatisticsId == 1).TotalCorrectAnswers;
                var totalQuestionsFromOverall = db.Get<OverallStatistics>(total => total.StatisticsId == 1).TotalQuestionsAttempted;
                var d = db.Get<OverallStatistics>(stat => stat.StatisticsId == 1);
                var newLongestStreak = 0;
               
                if (insertStatistics.LongestStreak > d.LongestOverallStreak)
                {
                    newLongestStreak = insertStatistics.LongestStreak;
                }
                else
                {
                    newLongestStreak = d.LongestOverallStreak;
                }

                var updatedStats = new OverallStatistics
                               {
                                   StatisticsId = 1,
                                   LongestOverallStreak = newLongestStreak,
                                   TotalCorrectAnswers = insertStatistics.TotalAnsweredCorrectly + correctAnswersFromOverall,
                                   TotalQuestionsAttempted = insertStatistics.TotalAnsweredCorrectly + 
                                                             insertStatistics.TotalAnsweredIncorrectly +
                                                             totalQuestionsFromOverall,
                               };

                db.Update(updatedStats);
                db.Commit();
            }
        }
    }
}
