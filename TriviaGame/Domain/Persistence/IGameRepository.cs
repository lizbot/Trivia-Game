﻿using System;
using System.Collections.Generic;
using Application.Model;

namespace Domain.Persistence
{
    public interface IGameRepository
    {
        GameSaved GetGameInProgress();

        Boolean IsGameInProgress();

        void DeleteGameInProgressIfExists();

        void MarkCorrectOrIncorrect(Int32 questionId, Boolean isCorrect);

        void StoreQuestionToGameInProgress(Int32 questionId, Int32 answerId);
    }
}