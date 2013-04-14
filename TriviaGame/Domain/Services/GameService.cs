using System;
using System.Collections.Generic;
using Application.Domain;
using Application.Model;
using Domain.Persistence;
using Application.Model;
using System.Collections.Generic;

namespace Domain.Services
{
    public class GameService : IGameService 
    {
        private readonly IGameRepository _GameRepository;
        
        public GameService(IGameRepository gameRepository) 
        {
            _GameRepository = gameRepository;
        }        
        
        public Boolean IsGameInProgress() 
        {
            var checkForGame = _GameRepository.IsGameInProgress();

            return checkForGame;
        }

        public void DeleteGameInProgressIfExists()
        {
            _GameRepository.DeleteGameInProgressIfExists();
        }


        public GameSaved GetGameInProgress()
        {
            return _GameRepository.GetGameInProgress();
        }
    }
}
