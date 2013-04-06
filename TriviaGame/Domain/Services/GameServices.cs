using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Persistence;


namespace Domain.Services
{
    public class GameServices
    {
        private readonly IGameRepository _GameRepository;
        
        public GameServices(IGameRepository gameRepository) 
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
