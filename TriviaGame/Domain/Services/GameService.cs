using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain;
using Domain.Persistence;


namespace Domain.Services
{
    public class GameService : IGameService 
    {
        private readonly IGameRepository _GameRepository;
        
        public GameService(IGameRepository gameRepository) 
        {
            _GameRepository = gameRepository;
        }        
        
        bool IsGameInProgress() 
        {
            bool checkForGame = _GameRepository.IsGameInProgress();

            return checkForGame;
        }
    }
}
