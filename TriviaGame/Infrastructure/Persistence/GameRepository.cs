﻿using System;
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
                //var currentGame = db.CreateCommand("SELECT Count(*) FROM GameSaved").ExecuteQuery<Model.GameSaved>().First();
                
                //return currentGame.AnswerId != 0 && currentGame.QuestionId != 0;

                var cmd = db.ExecuteScalar<Model.GameSaved>("SELECT * FROM GameSaved");

                //if (cmd.AnswerId == 0 && cmd.QuestionId == 0)
                //    return false;
                //else
                //{
                //    return true;
                //}

                //TODO(LM): FIGURE THIS PROBLEM OUT.
                return false;
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