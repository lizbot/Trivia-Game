using System.Collections.Generic;
using Application.Model;

namespace Application.Domain
{
    using System;

    public interface IGameService
    {
        Boolean IsGameInProgress();

        void DeleteGameInProgressIfExists();

        GameSaved GetGameInProgress();
    }
}