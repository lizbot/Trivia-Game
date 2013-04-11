using System;
using System.Collections.Generic;
using System.Linq;
using Application.Model;
using Domain.Persistence;
using Infrastructure.Initialization;
using SQLite;

namespace Infrastructure.Persistence
{
    public class GameRepository : IGameRepository
    {
        public IEnumerable<GameSaved> GetGameInProgress()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var questions = db.CreateCommand("SELECT QuestionId, AnswerId FROM GAMESAVED").ExecuteQuery<GameSaved>();
                var bo = questions;
                return bo;
            }
        }

        //public void StoreInitialGameInProgress(IEnumerable<Question> questionsToGameInProgress)
        //{
        //    using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
        //    {
        //        db.BeginTransaction();

        //        Model.GameSaved game;

        //        foreach (var question in questionsToGameInProgress)
        //        {
        //            db.Table<Model.GameSaved>();
        //            game = new Model.GameSaved
        //                {
        //                    QuestionId = question.QuestionId,
        //                    AnswerId = 0
        //                };
        //            db.Insert(game);

        //            db.Commit();
        //        }
        //    }
        //}

        public Boolean IsGameInProgress()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
               
                db.BeginTransaction();

                //var cmd = db.ExecuteScalar<Model.GameSaved>("SELECT * FROM GameSaved");
                var command = db.Query<Model.GameSaved>("SELECT * FROM GameSaved");

                if (command.Count == 0)
                {
                    return false;
                }
                else return true;
            }
        }

        public void DeleteGameInProgressIfExists()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.DeleteAll<GameSaved>();
            }
        }
    }
}