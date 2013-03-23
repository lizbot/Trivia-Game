using System.Collections.Generic;
using Domain.Model;

namespace Infrastructure.Persistence
{
    public interface IGameRepository
    {
        IEnumerable<GameSaved> GetGameInProgress();
    }
}