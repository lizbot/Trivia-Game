using System;
using Application.Domain;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _QuestionRepository;

        private readonly IOptionsService _OptionsService;
        private readonly IGameRepository _GameRepository;

        public QuestionService(
            IQuestionRepository questionRepository,
            IOptionsService optionsService,
            IGameRepository gameRepository)
        {
            _QuestionRepository = questionRepository;
            _OptionsService = optionsService;
            _GameRepository = gameRepository;
        }
        
        /// <summary>
        /// This method is written to get 20 generic questions, specific to quick-play.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Question> GetQuestions(Int32? categoryId = 0)
        {
            var userPreferredQuestionOption = _OptionsService.GetCustomOptions().NumberOfQuestionsDesired;

            var questions = _QuestionRepository.GetQuestions(userPreferredQuestionOption, categoryId);

            return questions;
        }

        public void StoreCustomQuestionsAndAnswers(String question, String rightAnswer, List<String> wrongAnswers)
        {
            _QuestionRepository.StoreCustomQuestionsAndAnswers(question, rightAnswer, wrongAnswers);
        }

        public void StoreAnsweredQuestion(Int32 questionId, Int32 answerId)
        {
            _GameRepository.StoreQuestionToGameInProgress(questionId, answerId);
        }

        public void IncrementTimesViewedAndOrTimesCorrect(Question question)
        {
            _QuestionRepository.IncreaseTimesCorrectAndOrTimesViewed(question);
        }

        public Question GetExistingQuestion(Int32 questionId)
        {
            return _QuestionRepository.GetQuestion(questionId);
        }
    }
}