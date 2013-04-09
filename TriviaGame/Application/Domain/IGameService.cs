namespace Application.Domain
{
    using System;

    public interface IGameService
    {
        Boolean IsGameInProgress();

        void DeleteGameInProgress();
    }
}