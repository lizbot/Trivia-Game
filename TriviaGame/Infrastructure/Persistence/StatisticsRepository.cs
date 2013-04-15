using System;
using Domain.Persistence;
using Infrastructure.Initialization;
using SQLite;

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

                //TODO:(Laura) analyze data.
                // From GameSaved table, we need total right, total wrong, and longest streak from the AnsweredCorrectly column.
                // Update end of game statistics into StatisticsId = 2 row of Statistics database if exists, otherwise Insert.
                
                /*
                 * 1. Analyze the data in the GameSaved 'AnsweredCorrectly' column.
                 *      a. Count how many were correct and store it in the 'TotalCorrectAnswers' column.
                 *      b.  Count how many were wrong and store it in the 'TotalWrongAnswers' column.
                 *      c. Write algorithm to find the longest streak of correct answers.
                 *      d. Put into EndOfGameStatistics object to use for other tasks. (endOfGameStats)
                 * 2. Insert this object into the EndOfGameStatistics table.
                 * 3. Get the object of the row in the overall statistics table. (currentStats)
                 * 4. Update the row in the OverallStatistics table:
                 *      a.  var updatedStats = new OverallStatistics
                 *              {
                 *                  StatisticsId = 1,
                 *                  StreakOfCorrectAnswers = max(currentLongestStreak, newLongestStreak),
                 *                  TotalCorrectAnswers = endOfGameStats.TotalCorrectAnswers + currentStats.TotalCorrectAnswers,
                 *                  TotalWrongAnswers = endOfGameStats.TotalWrongAnswers + currentStats.TotalWrongAnswers
                 *              }
                 * */

                db.Commit();
            }
        }
    }
}
