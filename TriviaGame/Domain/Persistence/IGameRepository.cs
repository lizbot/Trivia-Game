using System;
using System.Collections.Generic;
using Application.Model;

namespace Domain.Persistence
{
    public interface IGameRepository
    {
        IEnumerable<GameSaved> GetGameInProgress();

        Boolean IsGameInProgress();

        void DeleteGameInProgress();
    }
}