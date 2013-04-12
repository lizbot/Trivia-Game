using Application.Model;
using System;
using System.Collections.Generic;



namespace Application.Domain
{

    public interface IGameService
    {
        Boolean IsGameInProgress();

        IEnumerable<GameSaved> GetGameInProgress();

        void DeleteGameInProgressIfExists();
    }
}