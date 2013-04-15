using System;
using Application.Domain;
using Application.Model;
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

        public void MarkCorrectOrIncorrect(Int32 questionId, Boolean isCorrect)
        {
            _GameRepository.MarkCorrectOrIncorrect(questionId, isCorrect);
        }
    }
}
