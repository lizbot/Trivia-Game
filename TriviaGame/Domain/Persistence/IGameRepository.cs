using System;
using System.Collections.Generic;
using Application.Model;

namespace Domain.Persistence
{
    public interface IGameRepository
    {
        IEnumerable<GameSaved> GetGameInProgress();

<<<<<<< HEAD
        Boolean IsGameInProgress();
=======
        bool IsGameInProgress();
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
    }
}