using System;
using System.Linq;
using Application.Model;
using Domain.Persistence;
using Infrastructure.Initialization;
using SQLite;

namespace Infrastructure.Persistence
{
    public class GameRepository : IGameRepository
    {
        public QuestionRepository QuestionRepository = new QuestionRepository();

        public GameSaved GetGameInProgress()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var gameSavedTable = (from row in db.Table<Model.GameSaved>()
                                       select row).ToList();

                var questions = gameSavedTable.Select(row =>
                                    QuestionRepository.GetQuestion(row.QuestionId))
                                                      .ToList();

                var id = GetQuestionIdWhereGameWasLeftOff();

                var current = GetIfStreakStillApplicable();

                var game = new GameSaved
                    {
                        Questions = questions,
                        QuestionToResumeId = id
                    };

                return game;
            }
        }

        private static Boolean GetIfStreakStillApplicable()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var a = db.Get<Model.GameSaved>(game => game.AnswerId == 0).AnsweredCorrectly;


                throw new NotImplementedException();
                db.Commit();
            }
        }

        /// <summary>
        /// This stores the question answered to a game in progress so the user can pick up where they left off if they log off.
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="answerId"></param>
        public void StoreQuestionToGameInProgress(Int32 questionId, Int32 answerId)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var game = new Model.GameSaved
                {
                    AnswerId = answerId,
                    QuestionId = questionId
                };

                db.Update(game);

                db.Commit();
            }
        }

        private static Int32 GetQuestionIdWhereGameWasLeftOff()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var questionId = (from answer in db.Table<Model.GameSaved>()
                                  select answer)
                                    .First(a => a.AnswerId == 0)
                                    .QuestionId;
                db.Commit();

                return questionId;
            }
        }

        public Boolean IsGameInProgress()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
               
                db.BeginTransaction();

                var command = db.Query<Model.GameSaved>("SELECT * FROM GameSaved");

                return command.Count != 0;
            }
        }

        public void DeleteGameInProgressIfExists()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.DeleteAll<GameSaved>();
            }
        }

        public void MarkCorrectOrIncorrect(Int32 questionId, Boolean isCorrect)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var currentStateOfGame = db.Get<Model.GameSaved>(game => game.QuestionId == questionId);

                var updatedContent = new Model.GameSaved
                    {
                        AnsweredCorrectly = isCorrect,
                        AnswerId = currentStateOfGame.AnswerId,
                        QuestionId = questionId
                    };

                db.Update(updatedContent);

                db.Commit();
            }
        }
    }
}