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

        public Boolean IsGameInProgress()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
               // var currentGame = db.CreateCommand("SELECT Count(*) FROM GameSaved").ExecuteNonQuery();

               // var exists = currentGame != 0;

               // return exists;
                return false;
            }
        }

        public void DeleteGameInProgress()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.DeleteAll<GameSaved>();
            }
        }
    }
}