using System;
using Application.Domain;
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

            //return false;
        }

        public void DeleteGameInProgressIfExists()
        {
            _GameRepository.DeleteGameInProgressIfExists();
        }

        public IEnumerable<GameSaved> GetGameInProgress()
        {
            throw new NotImplementedException();
        }
    }
}
