using System.Collections.Generic;
using Domain.Model;

namespace Domain.Persistence
{
    public interface IGameRepository
    {
        IEnumerable<GameSaved> GetGameInProgress();
    }
}