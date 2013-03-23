using System;
using System.Collections.Generic;
using Domain.Model;

namespace Infrastructure.Persistence
{
    public class GameRepository : IGameRepository
    {
        public IEnumerable<GameSaved> GetGameInProgress()
        {
            throw new NotImplementedException();
        }
    }
}