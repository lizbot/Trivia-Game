using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
            // Currently on property will always be passed in as (for the prop on the gameSaved for iscorrect) 1
            // and update all other rows with that gameId to 0.
        }

        public Boolean IsGameInProgress()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                //var currentGame = db.ExecuteScalar<Boolean>("SELECT EXISTS(SELECT TOP 1 FROM GameSaved);");

               // return currentGame;
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