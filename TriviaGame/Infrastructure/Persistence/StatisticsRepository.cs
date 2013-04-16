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

                //TODO:(Laura) analyze data.
                // From GameSaved table, we need total right, total wrong, and longest streak from the AnsweredCorrectly column.
                // Update end of game statistics into StatisticsId = 2 row of Statistics database if exists, otherwise Insert.
                
                /*
                 * 1. Analyze the data in the GameSaved 'AnsweredCorrectly' column.
                 *      a. Count how many were correct and store it in the 'TotalCorrectAnswers' column.
                 */
                var correctlyAnsweredCol = (from AnsweredCorrectly in db.Table<Model.GameSaved>()
                                            select AnsweredCorrectly).Where(q => q.AnsweredCorrectly == true).Count();


                 /*     b.  Count how many were wrong and store it in the 'TotalWrongAnswers' column.
                  * */
                var incorrectlyAnswerCol = (from AnsweredCorrectly in db.Table<Model.GameSaved>()
                                            select AnsweredCorrectly).Where(q => q.AnsweredCorrectly == false).Count();


                 /*     c. Write algorithm to find the longest streak of correct answers.
                  */
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

                /*      d. Put into EndOfGameStatistics object to use for other tasks. (endOfGameStats)
                 */
                var insertStatistics = new EndOfGameStatistics 
                {
                    LongestStreak = totalStreak,
                    TotalAnsweredCorrectly = correctlyAnsweredCol,
                    TotalAnsweredIncorrectly = incorrectlyAnswerCol,
                };  

                 /* 2. Insert this object into the EndOfGameStatistics table.
                  */
                db.Insert(insertStatistics);

                 /* 3. Get the object of the row in the overall statistics table. (currentStats)
                  */
                var objectFromOverAllStatistics = db.Table<OverallStatistics>();

 
                 /* 4. Update the row in the OverallStatistics table:
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
