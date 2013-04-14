
﻿using Application.Model;
using System;
using System.Collections.Generic;



namespace Application.Domain
{

    public interface IGameService
    {
        Boolean IsGameInProgress();

        void DeleteGameInProgressIfExists();

        GameSaved GetGameInProgress();
    }
}