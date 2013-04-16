using Application.Model;
using System;

namespace Application.Domain
{
    public interface IGameService
    {
        Boolean IsGameInProgress();

        void DeleteGameInProgressIfExists();

        GameSaved GetGameInProgress();

        void MarkCorrectOrIncorrect(Int32 questionId, Boolean isCorrect);
    }
}